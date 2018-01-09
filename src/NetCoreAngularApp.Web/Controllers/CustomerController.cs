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

        private readonly Core.Data.CustomerRepository customerRepository;

        public CustomerController(Core.Data.CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Core.Data.Customer> Get()
        {
            return this.customerRepository.GetCustomers();
        }

        [HttpGet("{id}", Name = "Get")]
        public Core.Data.Customer Get(int id)
        {
            return this.customerRepository.GetCustomer(id);
        }

        [HttpPost]
        public void Post([FromBody]Core.Data.Customer customer)
        {
            //todo save code...
        }


        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }
}
