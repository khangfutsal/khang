using Microsoft.AspNetCore.Mvc;
using Project_KFoodSan_PTW_Temp.Reposistory;
using Project_KFoodSan_PTW_Temp.Models;

namespace Project_KFoodSan_PTW_Temp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryReposistory _categoryReposistory;
        public CategoryController(ICategoryReposistory categoryReposistory)
        {
            _categoryReposistory = categoryReposistory;
        }

        public IActionResult ViewAllCategories()
        {
            List<Category> categories = _categoryReposistory.GetAllCategories();
            return View("ViewAllCategories", categories);
        }


        //CreateCategory
        [HttpPost]
        public IActionResult SaveCategory(Category category)
        {
            if (ModelState.IsValid) // Valid
            {
                bool checkCategoryName = _categoryReposistory.checkCategoryName(category.CategoryName);
                if (checkCategoryName)// Same name in database
                {
                    ModelState.AddModelError(string.Empty, "Category name is exist");
                    return View("CreateCategory");
                }
                else // Not same name in database
                {
                    _categoryReposistory.Create(category);
                    return RedirectToAction("ViewAllCategories");
                }

            }
            return View("CreateCategory");


        }
        public IActionResult CreateCategory()
        {
            return View("CreateCategory", new Category());
        }

        //EditCategory
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryReposistory.Update(category);
            return RedirectToAction("ViewAllCategories");
        }
        public IActionResult EditCategory(int id)
        {
            return View("EditCategory", _categoryReposistory.CategoryGetById(id));
        }



        //DeleteCategory
        public IActionResult DeleteCategory(int id)
        {
            _categoryReposistory.Delete(id);
            return RedirectToAction("ViewAllCategories");
        }
    }

}
