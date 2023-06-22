using E_Commerce.Data;
using E_Commerce.Data.Services;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    [Authorize]
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
           
            _actorService = actorService;
        }

        public async Task< IActionResult>  Index()
        {
            var allActors = await _actorService.GetAll();    
           
            return View(allActors);
        }

        //Call for Form to enter the data
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
          await _actorService.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get Actor Detail With id
        public async Task<IActionResult> Details(int id)
        {
            var ActorDetails = await _actorService.GetById(id);
            if(ActorDetails == null) 
            {
                return View("NotFound");

            }
            return View(ActorDetails);
        }

        //Call for Form to enter the data
        public async Task<IActionResult> Edit(int id)
        {
            var ActorDetails = await _actorService.GetById(id);
            if (ActorDetails == null)
            {
                return View("NotFound");

            }
            return View(ActorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorService.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }


        //Call for Form to enter the data
        public async Task<IActionResult> Delete(int id)
        {
            var ActorDetails = await _actorService.GetById(id);
            if (ActorDetails == null)
            {
                return View("NotFound");

            }
            return View(ActorDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ActorDetails = await _actorService.GetById(id);
            if(ActorDetails == null)
            {
                return View("NotFound");
            }
            await _actorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
