using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly Core.IOrderRepository orderRepository;

        public ProductController(Core.IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public IEnumerable<Core.Models.Product> Get()
        {
            return this.orderRepository.GetProducts();
        }
    }
}