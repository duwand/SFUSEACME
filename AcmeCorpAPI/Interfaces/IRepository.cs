namespace AcmeCorpAPI.Interfaces
{
    public interface IRepository<CustomerModel> where CustomerModel : class
    {
        CustomerModel GetById(int id);
        IEnumerable<CustomerModel> GetAll();
        void Add(CustomerModel customer);
        void Update(CustomerModel customer);
        void Delete(int id);
        bool Exists (int id, string name);
    }

}