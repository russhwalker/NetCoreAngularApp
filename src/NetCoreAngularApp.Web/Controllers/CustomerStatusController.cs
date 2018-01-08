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

        [HttpGet]
        public IEnumerable<Models.CustomerStatus> Get()
        {
            for (int i = 1; i < 6; i++)
            {
                yield return new Models.CustomerStatus
                {
                    CustomerStatusId = i,
                    StatusText = $"Status{i}",
                };
            }
        }

        //[HttpGet("{id}", Name = "Get")]
        //public Models.CustomerStatus Get(int id)
        //{
        //    return new Models.CustomerStatus
        //    {
        //        CustomerStatusId = id,
        //        StatusText = $"Status{id}",
        //    };
        //}

    }
}
