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
    public class ProducersController : Controller
    {
       // private readonly AppDbContext _context;
       private readonly IProducerService   _producerService;

        public ProducersController(AppDbContext context, IProducerService producerService)
        {
            //_context = context;
            _producerService = producerService;
        }

        public async Task< IActionResult> Index()
        {
            var allProducers = await _producerService.GetAll();
            return View(allProducers);
        }

        //GET: producers/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //GET: producers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
           
            await _producerService.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //GET: producers/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if (id == producer.Id)
            {
                await _producerService.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        //GET: producers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");

            await _producerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
