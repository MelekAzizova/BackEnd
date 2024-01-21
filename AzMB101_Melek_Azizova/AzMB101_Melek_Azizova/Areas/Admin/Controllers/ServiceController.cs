using AzMB101_Melek_Azizova.Contexts;
using AzMB101_Melek_Azizova.Helpers;
using AzMB101_Melek_Azizova.Models;
using AzMB101_Melek_Azizova.ViewModels.PositionVM;
using AzMB101_Melek_Azizova.ViewModels.ServiceVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Index()
        {
            var data = await _db.Services.Select(s => new ServiceListItemVM
            {
                Id = s.Id,
                Image = s.Image,
                Title = s.Title,
                Position = s.Position,
               
				//ViewBag.Roles = context.Roles.Select(b => new SelectListItem { Value = b.Name, Text = b.Name });

		}).ToListAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            //@ViewBag.Positions=new SelecetList(_db.Position,"Id","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServiceCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
			//@ViewBag.Positions=new SelecetList(_db.Position,"Id","Name");
			Service service = new Service
            {
               
                Title=vm.Title,
                Position=vm.Position,
                Image=await vm.Image.SaveAsync(PathConst.Photo)


            };
            await _db.Services.AddAsync(service);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Services.FindAsync(id);
            if (data == null) return NotFound();
			//@ViewBag.Positions=new SelecetList(_db.Position,"Id","Name");
			_db.Services.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Services.FindAsync(id);
            if (data == null) return NotFound();
			//@ViewBag.Positions=new SelecetList(_db.Position,"Id","Name");
			return View(new ServiceUpdateVM
            {
                Position=data.Position,
                Title=data.Title,

            });

        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, ServiceUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.Services.FindAsync(id);
            if (data == null) return NotFound();
			//@ViewBag.Positions=new SelecetList(_db.Position,"Id","Name");
			data.Position = vm.Position;
            data.Title = vm.Title;
            data.Image = await vm.Image.SaveAsync(PathConst.Photo);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
