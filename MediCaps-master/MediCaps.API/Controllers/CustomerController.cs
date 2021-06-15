using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediCaps.BusinessLogic;
using MediCaps.DataAccess;
using MediCaps.DataAccess.Entities;

namespace MediCaps.API.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly signupService signupService;
        public CustomerController()
        {
            signupService = new signupService();
        }

        protected override void Dispose(bool disposing)
        {
            signupService.Dispose();
            base.Dispose(disposing);
        }

        [Route("Api/Customer/signup")]
        [HttpPost]
        public  IHttpActionResult Signup(Registration registration)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var signed = signupService.Add(registration);
            if (!signed)
                return BadRequest("SignUp Failed");
            return Ok(registration);
        }
    }
}
