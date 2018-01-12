﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreAngularApp.Core.Data
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }
    }
}