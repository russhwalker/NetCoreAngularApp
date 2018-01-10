using System.Collections.Generic;
using System.Linq;

namespace NetCoreAngularApp.Core.Data
{
    public class OrderRepository : IOrderRepository
    {

        private readonly StoreContext storeContext;

        public OrderRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Order GetOrder(int id)
        {
            return this.storeContext.Orders.Single(o => o.OrderId == id);
        }

        public List<Order> GetOrders(int customerId)
        {
            return this.storeContext.Orders.Where(o => o.CustomerId == customerId).ToList();
        }

    }
}