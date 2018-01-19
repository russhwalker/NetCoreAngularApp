using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreAngularApp.Core
{
    public interface IAddressRepository
    {
        Data.Address GetAddress(int id);
        List<Data.Address> GetAddresses(int customerId);
        bool SaveAddress(Data.Address address);
    }
}