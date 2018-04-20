using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreAngularApp.Core.Data
{
    public class AddressRepository : IAddressRepository
    {

        private readonly StoreContext storeContext;

        public AddressRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public List<Models.Address> GetAddresses(int customerId)
        {
            return AutoMapper.Mapper.Map<List<Models.Address>>(this.storeContext.Addresses.Where(a => a.CustomerId == customerId).ToList());
        }

        public Models.Address GetAddress(int id)
        {
            return AutoMapper.Mapper.Map<Models.Address>(this.storeContext.Addresses.Single(c => c.AddressId == id));
        }

        public bool SaveAddress(Models.Address address)
        {
            var entity = AutoMapper.Mapper.Map<Address>(address);
            if (address.AddressId == 0)
            {
                this.storeContext.Addresses.Add(entity);
            }
            else
            {
                this.storeContext.Addresses.Attach(entity);
                this.storeContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return this.storeContext.SaveChanges() > 0;
        }

    }
}