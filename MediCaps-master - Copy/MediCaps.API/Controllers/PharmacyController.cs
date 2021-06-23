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
using MediCaps.BusinessLogic;
using MediCaps.BusinessLogic.Repos;

namespace MediCaps.API.Controllers
{
    [RoutePrefix("api/pharmacy")]
    public class PharmacyController : ApiController
    {
        private readonly MedicapsContext context;
        private readonly PharmacyRepository phar;
        public PharmacyController()
        {
            context = new MedicapsContext();
            phar = new PharmacyRepository();
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

            var result = phar.GetPharamcy();
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
               
                var pharmacy = Mapper.Map<Pharmacy>(model);
                bool RowsAffected = phar.Add(pharmacy);
                if (RowsAffected)
                    return StatusCode(HttpStatusCode.Created);
                else
                    return BadRequest("This pharmacy already exist");
            }
            return StatusCode(HttpStatusCode.Unauthorized);
        }

        [HttpGet]
        [ResponseType(typeof(PharmacyResponse[]))]
        [Route("searchpin/{pin}")]
        public IHttpActionResult GetbyComposition(int pin)
        {
            var result = phar.GetPharmacybyPincode(pin);
            var response = Mapper.Map<PharmacyResponse[]>(result.ToArray());
            return Ok(response);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                    var deleted = phar.PharDelete(id);
                    if (deleted)
                        return StatusCode(HttpStatusCode.NoContent);
                    return BadRequest("Deletion Failed");
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        public IHttpActionResult Update(Pharmacy obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (obj == null)
                return BadRequest("Product is required");

            var result = phar.updatePharamacy(obj);
            if (result)
                return Ok();
            else
                return BadRequest("Update failed");

        }



    }
}
