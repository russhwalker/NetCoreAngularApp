using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/orderitems")]
    public class OrderItemsController : Controller
    {

        private readonly Core.IOrderRepository orderRepository;

        public OrderItemsController(Core.IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet("{id}", Name = "GetOrderItems")]
        public IEnumerable<Core.Models.OrderItem> Get(int id)
        {
            return this.orderRepository.GetOrderItems(id);
        }

    }
}