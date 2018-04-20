using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreAngularApp.Core
{
    public interface ICustomerRepository
    {

        List<Models.CustomerStatus> GetCustomerStatuses();

        List<Models.Customer> GetCustomers();

        Models.Customer GetCustomer(int id);

        Models.Customer SaveCustomer(Models.Customer customer);

    }
}