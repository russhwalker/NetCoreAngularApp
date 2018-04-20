using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/address")]
    public class AddressController : Controller
    {

        private readonly Core.IAddressRepository addressRepository;

        public AddressController(Core.IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        [HttpGet("{id}", Name = "GetAddress")]
        public Core.Models.Address Get(int id)
        {
            if (id == 0)
            {
                return new Core.Models.Address();
            }
            return this.addressRepository.GetAddress(id);
        }

        [HttpPost]
        public bool Post([FromBody]Core.Models.Address address)
        {
            return this.addressRepository.SaveAddress(address);
        }

    }
}