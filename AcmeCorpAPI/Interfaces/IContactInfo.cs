namespace AcmeCorpAPI.Interfaces
{
    public interface IContactInfo<ContactInfoModel> where ContactInfoModel : class
    {
        ContactInfoModel GetContactInfobyID (int id);
        void Add(ContactInfoModel contactInfo);
        void Update(ContactInfoModel contactInfo);
        void Delete(int id);
    }
}
