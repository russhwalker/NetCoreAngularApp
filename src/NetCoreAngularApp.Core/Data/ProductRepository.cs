using System.Collections.Generic;
using System.Linq;

namespace NetCoreAngularApp.Core.Data
{
    public class ProductRepository : IProductRepository
    {

        private readonly StoreContext storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Product GetProduct(int id)
        {
            return this.storeContext.Products.Single(p => p.ProductId == id);
        }

        public List<Product> GetProducts(int orderId)
        {
            return this.storeContext.Products.Where(p => p.OrderId == orderId).ToList();
        }

    }
}