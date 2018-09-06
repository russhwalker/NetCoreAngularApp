using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/orderitem")]
    public class OrderItemController : Controller
    {

        private readonly Core.IOrderRepository orderRepository;

        public OrderItemController(Core.IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpPost]
        public bool Post([FromBody]Core.Models.OrderItem orderItem)
        {
            return this.orderRepository.SaveOrderItem(orderItem);
        }

    }
}