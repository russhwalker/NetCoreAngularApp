using System;

namespace NetCoreAngularApp.Core.Models
{
    public class OrderItemView
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
    }
}