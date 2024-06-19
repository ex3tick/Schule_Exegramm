using Microsoft.AspNetCore.Mvc;
using WebApp.BusinessLayer;
using WebApp.Model.MelderModel;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BusinessLayer.BusinessLayer _business;

        public HomeController(IConfiguration configuration)
        {
            _business = new BusinessLayer.BusinessLayer(configuration);
        }
        
        public async Task<IActionResult> Index()
        {
         var sichtung = await _business.GetSichtungById(1);
         sichtung.Anmerkung = "Test";
         int id = await _business.InsertSichtung(sichtung);
         Console.WriteLine(id);
         
            
            return View();
        }
    }
}