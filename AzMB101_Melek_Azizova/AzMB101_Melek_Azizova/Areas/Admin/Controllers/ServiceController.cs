using AzMB101_Melek_Azizova.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AzMB101_Melek_Azizova.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class ServiceController : Controller
    {
        private readonly MaximDbContext _db;

        public ServiceController(MaximDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
