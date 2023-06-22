using E_Commerce.Data.Base;
using E_Commerce.Models;
using System.Threading.Tasks;

namespace E_Commerce.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        public Task<NewMovieDropdown> GetNewMovieDropdownsValues();
        public  Task AddNewMovieAsync(NewMovie data);
        public  Task UpdateMovieAsync(NewMovie data);
        public Task<Movie> GetMovieByIdAsync(int id);
    }
}
