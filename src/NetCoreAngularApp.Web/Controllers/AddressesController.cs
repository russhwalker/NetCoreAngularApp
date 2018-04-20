using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/addresses")]
    public class AddressesController : Controller
    {

        private readonly Core.IAddressRepository addressRepository;

        public AddressesController(Core.IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        [HttpGet("{id}", Name = "GetAddresses")]
        public IEnumerable<Core.Models.Address> Get(int id)
        {
            return this.addressRepository.GetAddresses(id);
        }

    }
}