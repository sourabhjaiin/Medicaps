using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediCaps.DataAccess;
using MediCaps.DataAccess.DTOs;
using MediCaps.BusinessLogic.Services;
using MediCaps.BusinessLogic.Repos;
using MediCaps.BusinessLogic;

namespace MediCaps.API.Controllers
{

    public class CartController : ApiController
    {
        public readonly MedicapsContext context;
        public readonly CartServices cartServices;
        public readonly MedicineRepository medicineRepository;

        public CartController()
        {
            context = new MedicapsContext();
            cartServices = new CartServices();
            medicineRepository = new MedicineRepository();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public IHttpActionResult CartItem(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var Items = cartServices.GetCart(id);
                if (Items == null)
                    return NotFound();
                return Ok(Items);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }

        }

        [HttpPost]
        public IHttpActionResult Post(Cartdto cartItem)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            var med = medicineRepository.GetM(cartItem.MedicineId);
            if (med == null)
                return BadRequest();

            cartItem.MedicinePrice = med.MedicinePrice;

            var added = cartServices.Add(cartItem);

            if (added == null)
                return BadRequest("Failed to add item to the cart");
            return Ok(cartItem);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {

                var deleted = cartServices.Remove(id);
                if (deleted)
                    return StatusCode(HttpStatusCode.NoContent);
                return BadRequest("Deletion Failed");

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("clearcart/{userId}")]
        public IHttpActionResult ClearCart(int userId)
        {
            try
            {
                var deleted = cartServices.ClearCart(userId);
                if (deleted)
                    return StatusCode(HttpStatusCode.NoContent);
                return BadRequest("Deletion Failed");

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }


        }
    }
}
