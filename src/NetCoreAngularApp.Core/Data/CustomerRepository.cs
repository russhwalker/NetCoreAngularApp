using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace NetCoreAngularApp.Core.Data
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly StoreContext storeContext;

        public CustomerRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public List<Models.CustomerStatus> GetCustomerStatuses()
        {
            return Mapper.Map<List<Models.CustomerStatus>>(this.storeContext.CustomerStatuses.ToList());
        }

        public List<Models.Customer> GetCustomers()
        {
            return Mapper.Map<List<Models.Customer>>(this.storeContext.Customers.ToList());
        }

        public Models.Customer GetCustomer(int id)
        {
            return Mapper.Map<Models.Customer>(this.storeContext.Customers.Single(c => c.CustomerId == id));
        }

        public Models.Customer SaveCustomer(Models.Customer customer)
        {
            var entity = Mapper.Map<Customer>(customer);
            if (customer.CustomerId == 0)
            {
                this.storeContext.Customers.Add(entity);
            }
            else
            {
                this.storeContext.Customers.Attach(entity);
                this.storeContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            this.storeContext.SaveChanges();
            return customer;
        }

    }
}
