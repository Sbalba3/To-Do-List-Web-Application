using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using To_Do_List_Web_Application.Models;
using To_Do_List_Web_Application.Repositry;

namespace To_Do_List_Web_Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<SysContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
          );
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ITaskRepo, TaskRepo>();
            builder.Services.AddScoped<IAccountRepository, AccountRepositiry>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();


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
                name: "default",
                pattern: "{controller=Tasks}/{action=Index}/{id?}");

            app.Run();
        }
    }
}