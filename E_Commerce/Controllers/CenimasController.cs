using E_Commerce.Data;
using E_Commerce.Data.Services;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    [Authorize]
    public class CenimasController : Controller
    {
        private readonly ICenimaService _cenimaService;

        public CenimasController(AppDbContext context, ICenimaService cenimaService)
        {
            
            _cenimaService = cenimaService;
        }

        public async Task< IActionResult>  Index()
        {
            var allCenimas = await _cenimaService.GetAll();
            return View(allCenimas);
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _cenimaService.GetByIdAsync(id);
            if(result==null) 
            {
                return View("NotFound");
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Discription")] Cenima cenimas)
        {
            if(!ModelState.IsValid)
            {
                return View(cenimas);
            }
            await _cenimaService.UpdateAsync(id,cenimas);
            return RedirectToAction(nameof(Index));


        }
        //Create Cenima 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Discription")] Cenima cenima)
        {
            if(!ModelState.IsValid)
            {
                return View(cenima);
            }

            await _cenimaService.AddAsync(cenima);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _cenimaService.GetByIdAsync(id);
            if(result==null)
            {
                return View("NotFound");
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cenimaService.GetByIdAsync(id);
            if(result==null)
            {
                return View("NotFound");
            }
            await _cenimaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));  
        }

      

    }
}
