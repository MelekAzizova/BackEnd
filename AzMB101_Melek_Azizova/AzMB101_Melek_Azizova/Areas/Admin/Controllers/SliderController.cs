using AzMB101_Melek_Azizova.Contexts;
using AzMB101_Melek_Azizova.Models;
using AzMB101_Melek_Azizova.ViewModels.MessageVM;
using AzMB101_Melek_Azizova.ViewModels.SliderVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace AzMB101_Melek_Azizova.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles ="Admin")]
	public class SliderController : Controller
	{
		private readonly MaximDbContext _db;

		public SliderController(MaximDbContext db)
		{
			_db = db;
		}

		public async  Task<IActionResult> Index()
		{
			var data = await _db.Sliders.Select(s => new SlideListItemVM
            {
				Id = s.Id,
				Title = s.Title,
			}).ToListAsync();
			return View(data);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(SliderCreateVM vm)
		{
			if(!ModelState.IsValid) return View(vm);
			Slider slider = new Slider
			{
				Title = vm.Title,
			};
			await _db.Sliders.AddAsync(slider);
			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		public async	Task<IActionResult> Delete(int? id)
		{
			if (id == null) return BadRequest();
			var data = await _db.Sliders.FindAsync(id);
			if(data==null) return NotFound();
			_db.Sliders.Remove(data);
			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

		}
		public async Task<IActionResult> Update(int? id)
		{
            if (id == null) return BadRequest();
            var data = await _db.Sliders.FindAsync(id);
            if (data == null) return NotFound();
			return View(new SliderUpdateVM 
			{
				Title=data.Title

			});

        }
		[HttpPost]
		public async Task<IActionResult> Update(int? id, SliderUpdateVM vm)
		{
            if (id == null) return BadRequest();
            var data = await _db.Sliders.FindAsync(id);
            if (data == null) return NotFound();
			data.Title = vm.Title;
			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

        }
	}
}
