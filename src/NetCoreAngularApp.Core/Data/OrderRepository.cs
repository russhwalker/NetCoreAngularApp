using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NetCoreAngularApp.Core.Models;

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

        public List<Models.OrderItemView> GetOrderItems(int orderId)
        {
            return
                this.storeContext.OrderItems.Where(a => a.OrderId == orderId)
                .Select(i => new Models.OrderItemView
                {
                    OrderItemId = i.OrderItemId,
                    OrderId = i.OrderId,
                    Price = i.Price,
                    ProductId = i.ProductId,
                    ProductName = i.Product.Description
                }).ToList();
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

        public bool SaveOrderItem(Models.OrderItem orderItem)
        {
            var entity = Mapper.Map<OrderItem>(orderItem);
            if (entity.OrderItemId == 0)
            {
                this.storeContext.OrderItems.Add(entity);
            }
            else
            {
                this.storeContext.OrderItems.Attach(entity);
                this.storeContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return this.storeContext.SaveChanges() > 0;
        }

        public List<Models.Product> GetProducts()
        {
            return Mapper.Map<List<Models.Product>>(this.storeContext.Products.ToList());
        }

    }
}