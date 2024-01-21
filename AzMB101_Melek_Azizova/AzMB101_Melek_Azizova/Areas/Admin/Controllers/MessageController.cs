using AzMB101_Melek_Azizova.Contexts;
using AzMB101_Melek_Azizova.Models;
using AzMB101_Melek_Azizova.ViewModels.MessageVM;
using AzMB101_Melek_Azizova.ViewModels.SliderVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzMB101_Melek_Azizova.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly MaximDbContext _db;

        public MessageController(MaximDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _db.Messages.Select(s => new MessageListItemVM
            {
                Id = s.Id,
                Name = s.Name,  
                Email = s.Email,
                Subject = s.Subject,
                Messages = s.Messages,
                
            }).ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MessageCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            Message mess = new Message
            {
                Name = vm.Name,
                Subject = vm.Subject,
                Email   = vm.Email,
                Messages = vm.Messages,

            };
            await _db.Messages.AddAsync(mess);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Messages.FindAsync(id);
            if (data == null) return NotFound();
            _db.Messages.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Messages.FindAsync(id);
            if (data == null) return NotFound();
            return View(new MessageUpdateVM
            {
                Name=data.Name,
                Subject=data.Subject,
                Email=data.Email,
                Messages = data.Messages,   

            });

        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, MessageUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.Messages.FindAsync(id);
            if (data == null) return NotFound();
            data.Name = vm.Name;
            data.Subject = vm.Subject;
            data.Email = vm.Email;
            data.Messages = vm.Messages;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
