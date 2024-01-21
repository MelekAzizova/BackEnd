using AzMB101_Melek_Azizova.Contexts;
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
            return View(data);
        }
    }
}
