using Microsoft.AspNetCore.Mvc;
using Project_KFoodSan_PTW_Temp.Models;
using Project_KFoodSan_PTW_Temp.Reposistory;
using Shop.Models;

namespace Project_KFoodSan_PTW_Temp.Controllers
{
    public class CartController : Controller
    {
        IFoodReposistory _foodReposistory;
        public CartController(IFoodReposistory foodReposistory)
        {
            _foodReposistory = foodReposistory;
        }

        public IActionResult Cart()
        {
            CartModel cartModel = new CartModel();
            cartModel.ID = HttpContext.Session.Id;
            cartModel.setAllItems(HttpContext.Session.Get<List<Item>>("cart"));
            if (HttpContext.Session.Get<List<Item>>("cart") != null && cartModel.getCountItems() != 0)
            {
                
                ViewBag.Msg = "having";
            }
            else
            {
                ViewBag.Msg = "not";
            }
            int? n = HttpContext.Session.GetInt32("nITems") == null ? 0 : HttpContext.Session.GetInt32("nITems");

            ViewBag.n = n;
            return View("Cart", cartModel);
        }
        public IActionResult UpdateQuantity()
        {
            var btnUpdate = Request.Form["btnUpdateQuantity"].ToString();
            var id = Request.Form["i.id"].ToString();
            //var quantity = Request.Form["i.quantity"].ToString();
            var quantity = 1;
            CartModel cartModel = null;
            if (HttpContext.Session.GetString("cart") != null)
            {
                cartModel = new CartModel();
                cartModel.ID = HttpContext.Session.Id;
                cartModel.setAllItems(HttpContext.Session.Get<List<Item>>("cart"));
            }
            cartModel.UpdateQuantity(btnUpdate, id, 1);
            HttpContext.Session.Set<List<Item>>("cart", cartModel.getAllItems());

            HttpContext.Session.SetInt32("nITems", cartModel.getCountItems());
            return RedirectToAction("Cart");
        }
        public IActionResult AddToCart(string id, string viewName)
        {
            Food f = _foodReposistory.FindFoodByID(id);
            ViewBag.SessionID = HttpContext.Session.Id;

            CartModel cartModel = null;
            int quantity = 1;
            if (HttpContext.Session.Get<List<Item>>("cart") != null)
            {
                cartModel = new CartModel();
                cartModel.ID = HttpContext.Session.Id;
                cartModel.setAllItems(HttpContext.Session.Get<List<Item>>("cart"));
                Item item = new Item()
                {
                    Id = f.Id.ToString(),
                    Img = f.Image,
                    Name = f.Name,
                    price = (double)f.Price,
                    quantity = quantity,
                    lineTotal = (double)(quantity * f.Price),
                };
                cartModel.AddItem(item);
                HttpContext.Session.Set<List<Item>>("cart", cartModel.getAllItems());

            }
            else
            {
                cartModel = new CartModel();
                cartModel.ID = HttpContext.Session.Id;
                Item item = new Item()
                {
                    Id = f.Id.ToString(),
                    Img = f.Image,
                    Name = f.Name,
                    price = (double)f.Price,
                    quantity = quantity,
                    lineTotal = (double)(quantity * f.Price),

                };
                cartModel.AddItem(item);
                HttpContext.Session.Set<List<Item>>("cart", cartModel.getAllItems());
            }

            HttpContext.Session.SetInt32("nITems", cartModel.getCountItems());

            int? n = HttpContext.Session.GetInt32("nITems");

            ViewBag.n = n;

            return RedirectToAction(viewName, "Home");
        }
        public IActionResult RemoveToCart()
        {
            var id = Request.Form["i.Id"];
            CartModel cartModel = null;
            if (HttpContext.Session.Get<List<Item>>("cart") != null)
            {
                cartModel = new CartModel();
                cartModel.setAllItems(HttpContext.Session.Get<List<Item>>("cart"));
            }
            cartModel.RemoveToCart(id);
            HttpContext.Session.Set<List<Item>>("cart",cartModel.getAllItems());

            HttpContext.Session.SetInt32("nITems", cartModel.getCountItems());
            return RedirectToAction("Cart");
        }

    }
}
