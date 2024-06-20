using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using WebApp.BusinessLayer;
using WebApp.Model.BildModel;
using WebApp.Model.KategorieModel;
using WebApp.Model.MelderModel;
using WebApp.Model.ModelSichtung;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ex3gramm API", Version = "v1" });
            });

            var app = builder.Build();

            app.UseSwagger();

           
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ex3gramm v1");
                c.RoutePrefix = string.Empty; 
            });

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}