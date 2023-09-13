using Microsoft.EntityFrameworkCore;
using Saloon1.Models;
using Microsoft.AspNetCore.Identity;
using Saloon1.Data;




namespace Saloon1
{
 public class Program
 {
  public static void Main(string[] args)
  {
   var builder = WebApplication.CreateBuilder(args);








   // Add services to the container.
   builder.Services.AddControllersWithViews();

   builder.Services.AddDbContext<Saloon1Context>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("Saloon1Context")));
   builder.Services.AddDbContext<Saloon2Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Saloon2Context")));


   builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Saloon2Context>();


 

   var app = builder.Build();

   // Configure the HTTP request pipeline.
   if (!app.Environment.IsDevelopment())
   {
    app.UseExceptionHandler("/Home/Error");
   }
   app.UseStaticFiles();

   app.UseRouting();

   app.UseAuthorization();
   app.MapRazorPages();

   app.MapControllerRoute(
       name: "default",
       pattern: "{controller=Home}/{action=Index}/{id?}");

   app.Run();
  }
 }
}