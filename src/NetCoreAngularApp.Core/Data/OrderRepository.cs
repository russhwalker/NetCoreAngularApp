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

        public List<Order> GetOrders()
        {
            return this.storeContext.Orders.ToList();
        }

        public List<Order> GetOrders(int customerId)
        {
            return this.storeContext.Orders.Where(a => a.CustomerId == customerId).ToList();
        }

        public bool SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                this.storeContext.Orders.Add(order);
            }
            else
            {
                this.storeContext.Orders.Attach(order);
                this.storeContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return this.storeContext.SaveChanges() > 0;
        }

    }
}