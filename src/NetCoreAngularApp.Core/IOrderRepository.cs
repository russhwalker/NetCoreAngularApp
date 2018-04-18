using System.Collections.Generic;

namespace NetCoreAngularApp.Core
{
    public interface IOrderRepository
    {
        Data.Order GetOrder(int id);
        List<Data.Order> GetOrders();
        List<Data.Order> GetOrders(int customerId);
        bool SaveOrder(Data.Order order);
    }
}