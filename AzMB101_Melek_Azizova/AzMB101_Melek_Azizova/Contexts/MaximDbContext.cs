using AzMB101_Melek_Azizova.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AzMB101_Melek_Azizova.Contexts
{
	public class MaximDbContext:IdentityDbContext
	{
        public MaximDbContext(DbContextOptions opt):base(opt) 
        {
            
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
