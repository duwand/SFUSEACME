using AcmeCorpAPI.DataContext;
using AcmeCorpAPI.Interfaces;
using AcmeCorpAPI.Models;

namespace AcmeCorpAPI.Repository
{
    public class ContactInfoRepository : IContactInfo<ContactInfoModel>
    {
        private readonly AppDbContext _context;

        public ContactInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        public ContactInfoModel GetContactInfobyID (int id)
        {
            return _context.ContactInfo.FirstOrDefault(x=> x.CustomerID == id);
        }

        public void Add(ContactInfoModel contactInfo)
        {
            _context.ContactInfo.Add(contactInfo);
            _context.SaveChanges();
        }
        public void Update(ContactInfoModel contactInfo)
        {
            _context.ContactInfo.Update(contactInfo);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var del = _context.ContactInfo.FirstOrDefault(x=> x.CustomerID == id);
            _context.ContactInfo.Remove(del);
            _context.SaveChanges();
        }


    }
}
