using AcmeCorpAPI.DataContext;
using AcmeCorpAPI.Interfaces;
using AcmeCorpAPI.Models;

namespace AcmeCorpAPI.Repository
{
    public class CustomerRepository : IRepository<CustomerModel>
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public CustomerModel GetById(int id)
        {
            return _context.Customer.Find(id);
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            return _context.Customer.ToList();
        }

        public void Add(CustomerModel customer)
        {
            
            _context.Customer.Add(customer);
            _context.SaveChanges();
        }

        public void Update(CustomerModel customer)
        {
            _context.Customer.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var del = _context.Customer.FirstOrDefault(x => x.CustomerID == id);
            _context.Customer.Remove(del);
            _context.SaveChanges();
        }
        public bool Exists(int id, string name)
        {
            return _context.Customer.Any(customer => customer.CustomerID == id || customer.Name == name);
        }


    }

}
