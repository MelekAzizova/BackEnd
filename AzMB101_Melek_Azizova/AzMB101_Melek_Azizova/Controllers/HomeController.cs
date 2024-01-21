using Microsoft.AspNetCore.Mvc;

namespace AzMB101_Melek_Azizova.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
