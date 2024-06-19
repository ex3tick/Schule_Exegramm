namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Konfiguration der Anwendung als MVC-Anwendung
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(
                               name: "default",
                                              pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
