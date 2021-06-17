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
using MediCaps.BusinessLogic.Repos;
using MediCaps.BusinessLogic;

namespace MediCaps.API.Controllers
{
    //[EnableCors("*", "*", "GET, POST, PUT")]
    [RoutePrefix("api/medicine")]
    public class MedicineController : ApiController
    {
        private readonly MedicapsContext context;
        private readonly MedicineRepository medRepo;
        public MedicineController()
        {
            context = new MedicapsContext ();
            medRepo = new MedicineRepository();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        

        [HttpGet]
        [ResponseType(typeof(ProductResponse[]))]
        public IHttpActionResult GetMedicine()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Medicine, ProductResponse>();
            });
            IMapper iMapper = config.CreateMapper();

            var result = medRepo.GetMed();
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
                
                bool RowsAffected = medRepo.Add(medicine); 

                if (RowsAffected)
                    return StatusCode(HttpStatusCode.Created);
                else
                    return InternalServerError();
            }
            return StatusCode(HttpStatusCode.Unauthorized);
        }



        [HttpGet]
        [ResponseType(typeof(ProductResponse[]))]
        [Route("{med}")]
        public IHttpActionResult GetbyName(string med)
        {
            var result = medRepo.GetMedicinebyName(med);
            var response = Mapper.Map<ProductResponse[]>(result.ToArray());
            return Ok(response);
        }

        [HttpGet]
        [ResponseType(typeof(ProductResponse[]))]
        [Route("{comp}")]
        public IHttpActionResult GetbyComposition(string comp)
        {
            var result = medRepo.GetMedicineByComposition(comp);
            var response = Mapper.Map<ProductResponse[]>(result.ToArray());
            return Ok(response);
        }

        [HttpGet]
        [ResponseType(typeof(ProductResponse[]))]
        [Route("{id}")]
        public IHttpActionResult GetbyId(int id)
        {
            var result = medRepo.GetMedicinebyId(id);
            var response = Mapper.Map<ProductResponse[]>(result.ToArray());
            return Ok(response);
        }





    }
}
