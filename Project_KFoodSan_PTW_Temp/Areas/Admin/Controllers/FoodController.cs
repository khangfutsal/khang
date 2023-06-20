using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_KFoodSan_PTW_Temp.Models;
using Project_KFoodSan_PTW_Temp.Reposistory;

namespace Project_KFoodSan_PTW_Temp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FoodController : Controller
    {
        public ICategoryReposistory _cateReposistory;
        public IFoodReposistory _foodReposistory;
        public FoodController(IFoodReposistory foodReposistory, ICategoryReposistory cateReposistory)
        {
            _cateReposistory = cateReposistory;
            _foodReposistory = foodReposistory;
        }
        public IActionResult ViewAllFood()
        {
            List<Food> f = _foodReposistory.GetAllFood().ToList();
            return View("ViewAllFood",f);
        }
        //CreateFood
        [HttpPost]
        public IActionResult SaveFood(Food food)
        {
            _foodReposistory.CreateFood(food);
            return RedirectToAction("ViewAllFood");
        }
        public IActionResult CreateFood()
        {
            var list1 = from c in _cateReposistory.GetAllCategories()
                        select new SelectListItem()
                        {
                            Text = c.CategoryName,
                            Value = c.Id.ToString(),
                            
                        };
            ViewBag.CategoryId = list1.ToList();
            return View("CreateFood",new Food());
        }
        //EditFood
        [HttpPost]
        public IActionResult UpdateFood(Food food)
        {
            _foodReposistory.UpdateFood(food);
            return RedirectToAction("ViewAllFood");
        }
        public IActionResult EditFood(string id)
        {
            var list1 = from c in _cateReposistory.GetAllCategories()
                        select new SelectListItem()
                        {
                            Text = c.CategoryName,
                            Value = c.Id.ToString(),

                        };
            ViewBag.CategoryId = list1.ToList();
            return View("EditFood", _foodReposistory.FindFoodByID(id));
        }
        //Delete
        public IActionResult DeleteFood(int id)
        {
            _foodReposistory.DeleteFood(id);
            return RedirectToAction("ViewAllFood");
        }
    }
}
