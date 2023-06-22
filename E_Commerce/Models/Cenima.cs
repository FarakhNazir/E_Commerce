using E_Commerce.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Cenima :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo")]
        public string Logo { get; set; }
        [Display (Name= "Name")]
        public string Name { get; set; }
        [Display (Name= "Description")]
        public string Discription { get; set; }
        //Relationships

        public List<Movie> Movies { get; set; }


    }
}
