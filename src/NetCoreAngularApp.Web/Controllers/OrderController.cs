using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/order")]
    public class OrderController : Controller
    {

        private readonly Core.IOrderRepository orderRepository;

        public OrderController(Core.IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public Core.Data.Order Get(int id)
        {
            if (id == 0)
            {
                return new Core.Data.Order();
            }
            return this.orderRepository.GetOrder(id);
        }

        [HttpPost]
        public bool Post([FromBody]Core.Data.Order order)
        {
            return this.orderRepository.SaveOrder(order);
        }

    }
}