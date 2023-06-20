using Microsoft.AspNetCore.Mvc;
using Project_KFoodSan_PTW_Temp.Models;
using Project_KFoodSan_PTW_Temp.Reposistory;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace Project_KFoodSan_PTW_Temp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IFoodReposistory _foodReposistory;
        private ICategoryReposistory _cateReposistory;
        public HomeController(ILogger<HomeController> logger, ICategoryReposistory cateReposistory, IFoodReposistory foodReposistory)
        {
            _logger = logger;
            _cateReposistory = cateReposistory;
            _foodReposistory = foodReposistory;
        }

        public IActionResult Index()
        {

            int? n = HttpContext.Session.GetInt32("nITems") == null ? 0 : HttpContext.Session.GetInt32("nITems");

            ViewBag.n = n;
            return View(_cateReposistory.GetAllCategories());
        }

        public IActionResult Menu()
        {

            int? n = HttpContext.Session.GetInt32("nITems")==null ? 0 : HttpContext.Session.GetInt32("nITems");

            ViewBag.n = n;
            return View(_cateReposistory.GetAllCategories());
        }
        public IActionResult About()
        {
            int? n = HttpContext.Session.GetInt32("nITems") == null ? 0 : HttpContext.Session.GetInt32("nITems");

            ViewBag.n = n;
            return View();
        }
        public IActionResult Careers()
        {
            int? n = HttpContext.Session.GetInt32("nITems") == null ? 0 : HttpContext.Session.GetInt32("nITems");

            ViewBag.n = n;
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}