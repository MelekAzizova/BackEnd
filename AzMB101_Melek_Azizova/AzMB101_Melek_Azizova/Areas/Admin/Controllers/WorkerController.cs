using AzMB101_Melek_Azizova.Contexts;
using AzMB101_Melek_Azizova.Helpers;
using AzMB101_Melek_Azizova.Models;
using AzMB101_Melek_Azizova.ViewModels.PositionVM;
using AzMB101_Melek_Azizova.ViewModels.WorkerVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzMB101_Melek_Azizova.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkerController : Controller
    {
        private readonly MaximDbContext _db;

        public WorkerController(MaximDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _db.Workers.Select(s => new WorkerListItemVM
            {
                Id = s.Id,
                Name = s.Name,
                Image=s.Image,
               

            }).ToListAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkerCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            Worker worker = new Worker
            {
                Name= vm.Name,
                Image=await vm.Image.SaveAsync(PathConst.Photo)
            };
            
            await _db.Workers.AddAsync(worker);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Workers.FindAsync(id);
            if (data == null) return NotFound();
            _db.Workers.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Workers.FindAsync(id);
            if (data == null) return NotFound();
            return View(new WorkerUpdateVM
            {
                Name = data.Name,
                

            });

        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, WorkerUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.Workers.FindAsync(id);
            if (data == null) return NotFound();
            data.Name = vm.Name;
            data.Image = await vm.Image.SaveAsync(PathConst.Photo);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
