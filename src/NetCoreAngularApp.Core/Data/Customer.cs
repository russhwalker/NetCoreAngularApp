﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreAngularApp.Core.Data
{
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public int CustomerStatusId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual CustomerStatus CustomerStatus { get; set; }
        public virtual ICollection<Address> Addreses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}