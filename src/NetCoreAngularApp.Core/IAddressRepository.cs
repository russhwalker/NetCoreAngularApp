using System.Collections.Generic;

namespace NetCoreAngularApp.Core
{
    public interface IAddressRepository
    {
        Models.Address GetAddress(int id);
        List<Models.Address> GetAddresses(int customerId);
        bool SaveAddress(Models.Address address);
    }
}