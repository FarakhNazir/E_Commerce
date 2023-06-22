using E_Commerce.Data.Base;
using E_Commerce.Data.Enum;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        [Display (Name= "Description")]
        public string Description { get; set; }
        [Display (Name = "Image URL")]
        public string ImgaeURL { get; set; }
        [Display (Name = "Movie Price")]
        public double Price { get; set; }
        [Display (Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display (Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display (Name = "Movie Category")]
        public MoviesCategory MoviesCategory { get; set; }
        //Relationships
        
        public List<Actor_Movie> Actors_Movies { get; set; }

        //Cenima
        public int CenimaId { get; set; }
        [ForeignKey("CenimaId")]
        public Cenima Cenima { get; set; }
        //Producer
        //Cenima
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

    }
}
