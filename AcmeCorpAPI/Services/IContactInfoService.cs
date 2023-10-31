using AcmeCorpAPI.Interfaces;
using AcmeCorpAPI.Models;
using AcmeCorpAPI.Repository;

namespace AcmeCorpAPI.Services
{
    public interface IContactInfoService
    {
        ContactInfoModel GetContactInfobyID(int id);
        void Add (ContactInfoModel contactInfo);
        void Update (ContactInfoModel contactInfo);
        void Delete(int id);
    }

    public class ContactInfoService : IContactInfoService
    {
        private readonly IContactInfo<ContactInfoModel> _contactinfoRepository;

        public ContactInfoService(IContactInfo<ContactInfoModel> customerRepository)
        {
            _contactinfoRepository = customerRepository;
        }

        public ContactInfoModel GetContactInfobyID(int id)
        {
            return _contactinfoRepository.GetContactInfobyID(id);
        }
        public void Add(ContactInfoModel contactInfo)
        {
           _contactinfoRepository.Add(contactInfo);
        }
        public void Update(ContactInfoModel contactInfo)
        {
           _contactinfoRepository.Update(contactInfo);
        }

        public void Delete(int id)
        {
           _contactinfoRepository.Delete(id);
        }


    }
}
