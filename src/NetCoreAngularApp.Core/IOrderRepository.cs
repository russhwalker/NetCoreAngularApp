using System.Collections.Generic;

namespace NetCoreAngularApp.Core
{
    public interface IOrderRepository
    {
        Models.Order GetOrder(int id);
        List<Models.Order> GetOrders();
        List<Models.Order> GetOrders(int customerId);
        bool SaveOrder(Models.Order order);
    }
}