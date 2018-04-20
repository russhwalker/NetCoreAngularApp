using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngularApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/orderdetail")]
    public class OrderDetailController : Controller
    {

        private readonly Core.ICustomerRepository customerRepository;
        private readonly Core.IOrderRepository orderRepository;

        public OrderDetailController(Core.ICustomerRepository customerRepository,
            Core.IOrderRepository orderRepository)
        {
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
        }

        [HttpGet("{id}", Name = "GetOrderDetail")]
        public Core.Models.OrderDetail Get(int id)
        {
            var order = this.orderRepository.GetOrder(id);
            var customer = this.customerRepository.GetCustomer(order.CustomerId);
            return new Core.Models.OrderDetail
            {
                Order = order,
                Customer = customer
            };
        }

    }

}