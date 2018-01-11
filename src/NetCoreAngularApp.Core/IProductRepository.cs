using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreAngularApp.Core
{
    public interface IProductRepository
    {
        Data.Product GetProduct(int id);
        List<Data.Product> GetProducts(int orderId);
    }
}