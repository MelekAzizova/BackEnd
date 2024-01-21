using AzMB101_Melek_Azizova.Contexts;
using AzMB101_Melek_Azizova.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace AzMB101_Melek_Azizova
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MaximDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql")));
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MaximDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();
			app.MapControllerRoute(
			name: "areas",
			pattern: "{area:exists}/{controller=Slider}/{action=Index}/{id?}"
		  );

			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            PathConst.RootPath = builder.Environment.WebRootPath;

            app.Run();
        }
    }
}