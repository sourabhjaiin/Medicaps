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
using AutoMapper;

namespace MediCaps.API.Controllers
{
    public class PharmacyController : ApiController
    {
        private readonly MedicapsContext context;
        public PharmacyController()
        {
            context = new MedicapsContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        [ResponseType(typeof(PharmacyResponse[]))]
        public IHttpActionResult GetPharmacy()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Pharmacy, PharmacyResponse>();
            });
            IMapper iMapper = config.CreateMapper();

            var result = context.Pharmacies.ToArray();
            var pharmacyresponse = iMapper.Map<PharmacyResponse[]>(result);
            return Ok(pharmacyresponse);
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult Post([FromBody] PharmacyRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (context.Logins.Find(model.UserId)?.UserType == UserType.Admin)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Pharmacy, PharmacyRequest>();
                });
                IMapper iMapper = config.CreateMapper();
                var pharmacy = iMapper.Map<Pharmacy>(model);
                context.Pharmacies.Add(pharmacy);
                int RowsAffected = context.SaveChanges();
                if (RowsAffected == 1)
                    return StatusCode(HttpStatusCode.Created);
                else
                    return InternalServerError();
            }
            return StatusCode(HttpStatusCode.Unauthorized);
        }

    }
}
