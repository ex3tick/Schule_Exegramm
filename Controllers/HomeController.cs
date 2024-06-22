using Microsoft.AspNetCore.Mvc;
using WebApp.BusinessLayer;
using WebApp.Model.BildModel;
using WebApp.Model.KategorieModel;
using WebApp.Model.MelderModel;
using WebApp.Model.ModelSichtung;

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
            return View();
        }


        #region Melder

      

        #endregion


    }
}