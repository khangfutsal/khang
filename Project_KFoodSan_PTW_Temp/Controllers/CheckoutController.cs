using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_KFoodSan_PTW_Temp.Models;
using Project_KFoodSan_PTW_Temp.Reposistory;

namespace Project_KFoodSan_PTW_Temp.Controllers
{
    public class CheckoutController : Controller
    {
        IOrderBookReposistory _orderBookReposistory;
        ICountryReposistory _countryReposistory;
        public CheckoutController(IOrderBookReposistory orderBookReposistory, ICountryReposistory countryReposistory)
        {
            _orderBookReposistory = orderBookReposistory;
            _countryReposistory= countryReposistory;
        }
        public IActionResult Checkout()
        {
            var list1 = from c in _countryReposistory.getAllCountry()
                        select new SelectListItem()
                        {
                            Text = c.CountryName,
                            Value = c.Id.ToString(),

                        };
            ViewBag.CountryId = list1.ToList();
            int? n = HttpContext.Session.GetInt32("nITems") == null ? 0 : HttpContext.Session.GetInt32("nITems");

            ViewBag.n = n;
            return View();
        }
        public IActionResult HandleCheckout(OrderBook orderBook)
        {
            _orderBookReposistory.UpdateOrderBook(orderBook);
            return RedirectToAction("Checkout");
        }
    }
}
