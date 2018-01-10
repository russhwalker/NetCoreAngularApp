using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreAngularApp.Core
{
    public interface IOrderRepository
    {
        Data.Order GetOrder(int id);
        List<Data.Order> GetOrders(int customerId);
    }
}