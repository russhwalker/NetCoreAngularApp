using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreAngularApp.Core
{
    public interface ICustomerRepository
    {

        List<Data.CustomerStatus> GetCustomerStatuses();

        List<Data.Customer> GetCustomers();

        Data.Customer GetCustomer(int id);

        bool SaveCustomer(Data.Customer customer);

    }
}