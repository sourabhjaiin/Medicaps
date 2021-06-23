using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediCaps.DataAccess;
using MediCaps.BusinessLogic;
using MediCaps.DataAccess.Entities;

namespace MediCaps.API.Controllers
{
    public class OrderController : ApiController
    {
        public readonly MedicapsContext context;
        public OrderController()
        {
            context = new MedicapsContext();
        }

        [HttpPost]
        public IHttpActionResult PostOrder(Order order)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");

            context.Orders.Add(new Order()
            {
                ID = order.ID,
                UserId = order.UserId,
                DeliveryAddress = order.DeliveryAddress,
                OrderDate = order.OrderDate,
                Amount = order.Amount
            });

            var row = context.SaveChanges();
            if (row == null)
                return BadRequest();
            return Ok(order);

        }
    }
}
