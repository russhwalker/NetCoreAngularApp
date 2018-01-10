using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/customerstatus")]
    public class CustomerStatusController : Controller
    {

        private readonly Core.ICustomerRepository customerRepository;

        public CustomerStatusController(Core.ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Core.Data.CustomerStatus> Get()
        {
            return this.customerRepository.GetCustomerStatuses();
        }

    }
}
