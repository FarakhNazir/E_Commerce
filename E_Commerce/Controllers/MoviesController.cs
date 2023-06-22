using E_Commerce.Data;
using E_Commerce.Data.Base;
using E_Commerce.Data.Services;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
       
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService, AppDbContext context)
        {
            _moviesService = moviesService;
          
        }

       

        public async Task<IActionResult>  Index()
        {
           

            var allMovies = await _moviesService.GetAllAsync(n => n.Cenima);
            return View(allMovies);
          
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
           

            var moviesall = await _moviesService.GetAllAsync(n => n.Cenima);

            
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = moviesall.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

               // var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResult);
            }

            return View("Index", moviesall);
        }

    
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _moviesService.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
           
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _moviesService.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _moviesService.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _moviesService.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovie()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImgaeURL,
                MovieCategory = movieDetails.MoviesCategory,
                CinemaId = movieDetails.CenimaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };

            var movieDropdownsData = await _moviesService.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovie movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _moviesService.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _moviesService.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _moviesService.GetMovieByIdAsync(id);
            return View(movieDetail);
        }
    }
}
