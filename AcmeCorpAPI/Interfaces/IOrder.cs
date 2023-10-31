using AcmeCorpAPI.Models;

namespace AcmeCorpAPI.Interfaces
{
    public interface IOrder<OrderModel> where OrderModel : class
    {
        OrderModel GetOrderbyCustomerID(int id);
        IEnumerable<OrderModel> GetAllOrders();
    }
}
