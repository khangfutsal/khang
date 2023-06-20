using Microsoft.AspNetCore.Mvc;
using Project_KFoodSan_PTW_Temp.Models;

namespace Project_KFoodSan_PTW_Temp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
			User userData = TempData["UserData"] as User;
			return View("Index",userData);
        }
    }
}
