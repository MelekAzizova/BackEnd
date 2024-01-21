using AzMB101_Melek_Azizova.Contexts;
using AzMB101_Melek_Azizova.Models;
using AzMB101_Melek_Azizova.ViewModels.HomeVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzMB101_Melek_Azizova.Controllers
{
    public class HomeController : Controller
    {
        private readonly MaximDbContext _db;

        public HomeController(MaximDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _db.Services.ToListAsync();
            var itm=await _db.Workers.ToListAsync();
            var slider=await _db.Sliders.ToListAsync();
            var message=await _db.Messages.ToListAsync();
            

            HomeVM vm = new()
            {
                Services = data,
                Workers=itm,
                Messages=message,
                Sliders=slider
			    
            };
           
            return View(vm);
        }
    }
}
