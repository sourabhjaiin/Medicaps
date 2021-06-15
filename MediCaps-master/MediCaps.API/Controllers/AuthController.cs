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


using System.Web.Http.Description;

namespace MediCaps.API.Controllers
{

    
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
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
    }
}
