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
    //[EnableCors("*", "*", "GET, POST, PUT")]
    [RoutePrefix("api/companies")]
    public class MedicineController : ApiController
    {
        private readonly MedicapsContext context;
        public MedicineController()
        {
            context = new MedicapsContext ();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        

        [HttpGet]
        [ResponseType(typeof(ProductResponse[]))]
        public IHttpActionResult Get()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Medicine, ProductResponse>();
            });
            IMapper iMapper = config.CreateMapper();

            var result = context.Medicines.ToArray();
            var productresponse = iMapper.Map<ProductResponse[]>(result);
            return Ok(productresponse);
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult Post([FromBody] ProductRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (context.Logins.Find(model.UserId)?.UserType == UserType.Admin)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Medicine, ProductRequest>();
                });
                IMapper iMapper = config.CreateMapper();
                var medicine = iMapper.Map<Medicine>(model);
                context.Medicines.Add(medicine);
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
