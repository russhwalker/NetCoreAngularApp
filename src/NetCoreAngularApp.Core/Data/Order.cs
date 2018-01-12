
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreAngularApp.Core.Data
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}