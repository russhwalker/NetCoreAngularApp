using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/orders")]
    public class OrdersController : Controller
    {

        private readonly Core.IOrderRepository orderRepository;

        public OrdersController(Core.IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet("{id}", Name = "GetOrders")]
        public IEnumerable<Core.Data.Order> Get(int id)
        {
            return this.orderRepository.GetOrders(id);
        }

    }
}