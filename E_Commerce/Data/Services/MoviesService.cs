using E_Commerce.Data.Base;
using E_Commerce.Models;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace E_Commerce.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _appDbContext;
        public MoviesService(AppDbContext context, AppDbContext appDbContext) : base(context)
        {
            _appDbContext = appDbContext;
        }

        public async Task<NewMovieDropdown> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdown()
            {
                Actors = await _appDbContext.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _appDbContext.Cenimas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _appDbContext.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task AddNewMovieAsync(NewMovie data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImgaeURL = data.ImageURL,
                CenimaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MoviesCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };
            await _appDbContext.Movies.AddAsync(newMovie);
            await _appDbContext.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _appDbContext.Actors_Movies.AddAsync(newActorMovie);
            }
            await _appDbContext.SaveChangesAsync();
        }



        //Update Movie

        public async Task UpdateMovieAsync(NewMovie data)
        {
            var dbMovie = await _appDbContext.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImgaeURL = data.ImageURL;
                dbMovie.CenimaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MoviesCategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;
                await _appDbContext.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _appDbContext.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _appDbContext.Actors_Movies.RemoveRange(existingActorsDb);
            await _appDbContext.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _appDbContext.Actors_Movies.AddAsync(newActorMovie);
            }
            await _appDbContext.SaveChangesAsync();
        }


        //GEt Data of the Movie
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _appDbContext.Movies
                .Include(c => c.Cenima)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

    }
}
