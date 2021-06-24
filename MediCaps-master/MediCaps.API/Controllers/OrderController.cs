using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediCaps.DataAccess;
using MediCaps.BusinessLogic;
using MediCaps.DataAccess.Entities;
using MediCaps.DataAccess.DTOs;

namespace MediCaps.API.Controllers
{
    
    public class OrderController : ApiController
    {
        public readonly MedicapsContext context;
        public OrderController()
        {
            context = new MedicapsContext();
        }

        //[HttpGet]
        //public IHttpActionResult Getorder()
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Invalid Data");


        //}

        [HttpPost]
        public IHttpActionResult PostOrder(OrderDto order)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");

            OrderPlaced orderPlaced = new OrderPlaced
            {
                Address = order.Address,
                UserId = order.UserId,
                CartId = order.CartId
            };

            context.OrderPlaceds.Add(orderPlaced);

            

            var row = context.SaveChanges();
            int id = orderPlaced.OrderId;
            if (row <= 0)
                return BadRequest();
            return Ok(id);

        }

        [HttpDelete]
        public IHttpActionResult DeleteOrder(int id)
        {
            var ord = context.OrderPlaceds.Find(id);
            context.OrderPlaceds.Remove(ord);
            context.SaveChanges();
            return Ok();
        }

    }

   
}
