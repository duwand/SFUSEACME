using System.ComponentModel.DataAnnotations;

namespace AcmeCorpAPI.Models.AccountModels
{
    public class SignInModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
