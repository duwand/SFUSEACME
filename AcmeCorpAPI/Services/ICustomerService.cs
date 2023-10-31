using AcmeCorpAPI.Interfaces;
using AcmeCorpAPI.Models;

namespace AcmeCorpAPI.Services
{
    public interface ICustomerService
    {
        CustomerModel GetCustomerById(int customerId);
        IEnumerable<CustomerModel> GetAll();
        void Add(CustomerModel customer);
        void Update(CustomerModel customer);
        void Delete(int id);
        bool Exists(int id, string name);
    }

    public class CustomerService : ICustomerService
    {
        private readonly IRepository<CustomerModel> _customerRepository;

        public CustomerService(IRepository<CustomerModel> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerModel GetCustomerById(int customerId)
        {
            return _customerRepository.GetById(customerId);
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            return _customerRepository.GetAll();
        }
        public void Add(CustomerModel customer)
        {
            _customerRepository.Add(customer);
        }
        public void Update(CustomerModel customer)
        {
            _customerRepository.Update(customer);
        }
        public bool Exists(int id, string name)
        {
            return _customerRepository.Exists(id, name);
        }

        public void Delete(int id)
        {
            _customerRepository.Delete(id);
        }


    }

}
