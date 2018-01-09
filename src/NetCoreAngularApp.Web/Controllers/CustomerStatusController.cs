using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/customerstatus")]
    public class CustomerStatusController : Controller
    {

        private readonly Core.Data.CustomerRepository customerRepository;

        public CustomerStatusController(Core.Data.CustomerRepository customerRepository)
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
