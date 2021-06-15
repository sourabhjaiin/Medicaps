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
    public class AdminController : ApiController
    {
        private readonly LoginService LoginService;
        private readonly MedicineRepository medicineRepository;
        private readonly PharmacyRepository pharmacyRepository;
        public AdminController()
        {
            LoginService = new LoginService();
            medicineRepository = new MedicineRepository();
            pharmacyRepository = new PharmacyRepository();
        }

        protected override void Dispose(bool disposing)
        {
            LoginService.Dispose();
            base.Dispose(disposing);
        }

        [Route("Api/Admin/UserLogin")]
        [HttpPost]
        public IHttpActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var isvalid = LoginService.ValidatedAdmin(login);
            if (!isvalid)
                return BadRequest("Invalid username/password");
            return Ok(login.UserName);
        }


    }
}
