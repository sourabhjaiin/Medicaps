using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediCaps.DataAccess.DTOs;
using MediCaps.DataAccess;
using MediCaps.DataAccess.Entities;
using MediCaps.BusinessLogic.Services;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


using System.Web.Http.Description;

namespace MediCaps.API.Controllers
{
    //[Route("api/auth")]
    public class AuthController : ApiController
    {
        readonly LoginService service;
        public AuthController()
        {
            this.service = new LoginService();
        }

        [HttpPost]
        [Route("api/auth/login")]
        public IHttpActionResult Post([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IHttpActionResult response = BadRequest("Invalid username/password");

            using (var context = new MedicapsContext())
            {
                if (context.Logins.Any(u => u.UserName == model.UserName && u.Password == model.Password))
                {
                    var result = (from user in context.Logins
                                  where user.UserName == model.UserName
                                  select new { user.UserId, user.UserName, user.UserType }).Single();
                    response = Ok(new LoginResponse { UserId = result.UserId, UserName = result.UserName, UserType = result.UserType.ToString() });
                }
            }
            return response;
        }

        [HttpPost]
        [Route("api/auth/register")]
        public IHttpActionResult AddUser([FromBody] LoginDto user)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return BadRequest(ModelState);

                var result = service.AddUser(user);
                if (!result)
                    return BadRequest("Error saving user");

                //SendMail(user);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
