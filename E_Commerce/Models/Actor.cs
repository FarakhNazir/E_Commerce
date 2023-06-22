using E_Commerce.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display (Name = "Profile Pictur URL")]
        [Required (ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL{ get; set; }


        
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "Name must between 3 and  50 chars")]
        public string FullName { get; set; }


        
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biogrpaghy is required")] 
        public string Bio { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
        
    }
}
