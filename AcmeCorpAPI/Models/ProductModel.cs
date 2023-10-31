using System.ComponentModel.DataAnnotations;

namespace AcmeCorpAPI.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
