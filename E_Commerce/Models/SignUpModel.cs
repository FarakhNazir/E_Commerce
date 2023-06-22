using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace E_Commerce.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = " First Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = " First Name must have atleast 3 and almost 50 chars")]
        public string FullName { get; set; }
        
        
       


        [Required(ErrorMessage = "Phone Number is Required")]

        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; } 

        [Required(ErrorMessage = " Email Address is Required ")]
        [EmailAddress]
        public string Email { get; set; }
        
       

        [Required (ErrorMessage = "password must be Required")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
       
        
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
