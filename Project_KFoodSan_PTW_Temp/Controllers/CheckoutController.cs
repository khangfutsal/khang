using Microsoft.AspNetCore.Mvc;

namespace Project_KFoodSan_PTW_Temp.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Checkout()
        {
            int? n = HttpContext.Session.GetInt32("nITems") == null ? 0 : HttpContext.Session.GetInt32("nITems");

            ViewBag.n = n;
            return View();
        }
    }
}
