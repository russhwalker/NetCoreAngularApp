using System;

namespace NetCoreAngularApp.Core.Models
{
    public class OrderDetail
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }
}