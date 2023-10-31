using AcmeCorpAPI.Interfaces;
using AcmeCorpAPI.Models;
using AcmeCorpAPI.Repository;

namespace AcmeCorpAPI.Services
{
    public interface IOrderService
    {
        OrderModel GetOrderbyCustomerID(int id);
        IEnumerable<OrderModel> GetAllOrders();
    }

    public class OrderService : IOrderService
    {
        private readonly IOrder<OrderModel> _orderRepository;

        public OrderService(IOrder<OrderModel> orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public OrderModel GetOrderbyCustomerID(int id)
        {
            return _orderRepository.GetOrderbyCustomerID(id);
        }

        public IEnumerable<OrderModel> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }



    }




}
