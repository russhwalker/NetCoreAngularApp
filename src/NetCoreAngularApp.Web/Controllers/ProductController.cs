using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/product")]
    public class ProductController : Controller
    {

        private readonly Core.IProductRepository productRepository;

        public ProductController(Core.IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public Core.Data.Product Get(int id)
        {
            if (id == 0)
            {
                return new Core.Data.Product();
            }
            return this.productRepository.GetProduct(id);
        }

        [HttpPost]
        public bool Post([FromBody]Core.Data.Product product)
        {
            return this.productRepository.SaveProduct(product);
        }

    }
}