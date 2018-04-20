using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace NetCoreAngularApp.Core.Data
{
    public class OrderRepository : IOrderRepository
    {

        private readonly StoreContext storeContext;

        public OrderRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Models.Order GetOrder(int id)
        {
            return Mapper.Map<Models.Order>(this.storeContext.Orders.Single(o => o.OrderId == id));
        }

        public List<Models.Order> GetOrders()
        {
            return Mapper.Map<List<Models.Order>>(this.storeContext.Orders.ToList());
        }

        public List<Models.Order> GetOrders(int customerId)
        {
            return Mapper.Map<List<Models.Order>>(this.storeContext.Orders.Where(a => a.CustomerId == customerId).ToList());
        }

        public bool SaveOrder(Models.Order order)
        {
            var entity = Mapper.Map<Order>(order);
            if (entity.OrderId == 0)
            {
                this.storeContext.Orders.Add(entity);
            }
            else
            {
                this.storeContext.Orders.Attach(entity);
                this.storeContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return this.storeContext.SaveChanges() > 0;
        }

    }
}