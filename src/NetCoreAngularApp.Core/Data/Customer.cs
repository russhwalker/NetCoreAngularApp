using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngularApp.Core.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int CustomerStatusId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual CustomerStatus CustomerStatus { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}