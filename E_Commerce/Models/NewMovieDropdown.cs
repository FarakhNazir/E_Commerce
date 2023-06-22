using System.Collections.Generic;

namespace E_Commerce.Models
{
    public class NewMovieDropdown
    {
        public NewMovieDropdown()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cenima>();
            Actors = new List<Actor>();
        }

        public List<Producer> Producers { get; set; }
        public List<Cenima> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
