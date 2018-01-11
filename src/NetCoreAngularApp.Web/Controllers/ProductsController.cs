using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductsController : Controller
    {

        private readonly Core.IProductRepository productRepository;

        public ProductsController(Core.IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("{id}", Name = "GetProducts")]
        public IEnumerable<Core.Data.Product> Get(int id)
        {
            var products = this.productRepository.GetProducts(id);
            return products;
        }

    }
}