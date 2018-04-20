using System;

namespace NetCoreAngularApp.Core.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int CustomerStatusId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}