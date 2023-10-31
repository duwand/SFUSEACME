using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeCorpAPI.Models
{
    public class ContactInfoModel
    {
        [Key]
        public int ContactID { get; set; }
        public int CustomerID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
