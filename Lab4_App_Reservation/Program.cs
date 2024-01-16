using Lab4_App_Reservation.Models;
using Data;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lab4_App_Reservation.Models.ContactModels;
using Lab4_App_Reservation.Models.ReservationModels;
using Lab4_App_Reservation.Models.ContactModels;
using Lab4_App_Reservation.Models.ReservationModels;

namespace Lab4_App_Reservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<IContactService, MemoryContactService>();
            builder.Services.AddTransient<IContactService, EFContactService>();
            builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();

            builder.Services.AddSingleton<IReservationService, MemoryReservationService>();
            builder.Services.AddTransient<IReservationService, EFReservationService>();

            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseMiddleware<LastVisitCookie>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}