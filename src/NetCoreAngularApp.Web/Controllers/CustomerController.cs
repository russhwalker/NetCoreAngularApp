using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {

        private readonly Core.ICustomerRepository customerRepository;

        public CustomerController(Core.ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Core.Data.Customer> Get()
        {
            return this.customerRepository.GetCustomers();
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public Core.Data.Customer Get(int id)
        {
            if(id == 0)
            {
                return new Core.Data.Customer
                {
                    CustomerStatusId = 1
                };
            }
            return this.customerRepository.GetCustomer(id);      
        }

        [HttpPost]
        public Core.Data.Customer Post([FromBody]Core.Data.Customer customer)
        {
            return this.customerRepository.SaveCustomer(customer);
        }

    }
}
