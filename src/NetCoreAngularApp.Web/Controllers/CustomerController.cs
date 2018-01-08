using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {

        [HttpGet]
        public IEnumerable<Models.Customer> Get()
        {
            for (int i = 1; i < 6; i++)
            {
                yield return new Models.Customer
                {
                    CustomerId = i,
                    CustomerStatusId = 1,
                    FirstName = $"John{i}",
                    LastName = "Doe"
                };
            }
        }


        [HttpGet("{id}", Name = "Get")]
        public Models.Customer Get(int id)
        {
            return new Models.Customer
            {
                CustomerId = id,
                FirstName = $"John{id}",
                LastName = "Doe"
            };
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
