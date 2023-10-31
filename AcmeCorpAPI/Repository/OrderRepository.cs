using AcmeCorpAPI.DataContext;
using AcmeCorpAPI.Interfaces;
using AcmeCorpAPI.Models;

namespace AcmeCorpAPI.Repository
{
    public class OrderRepository : IOrder<OrderModel>
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public OrderModel GetOrderbyCustomerID(int id)
        {
            return _context.Orders.FirstOrDefault(x=> x.CustomerID == id);
        }
        public IEnumerable<OrderModel> GetAllOrders()
        {
            return _context.Orders.ToList();
        }



    }
}
