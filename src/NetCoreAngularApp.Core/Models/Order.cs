﻿using System;

namespace NetCoreAngularApp.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}