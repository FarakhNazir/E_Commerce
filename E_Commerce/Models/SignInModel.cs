using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage ="Email Not be Null")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
