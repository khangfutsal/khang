using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_KFoodSan_PTW_Temp.Models;
using Project_KFoodSan_PTW_Temp.Reposistory;

namespace Project_KFoodSan_PTW_Temp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        public IUserReposistory _userReposistory;
        public IRoleReposistory _roleReposistory;
        public UserController(IUserReposistory userReposistory, IRoleReposistory roleReposistory)
        {
            _userReposistory = userReposistory;
            _roleReposistory = roleReposistory;
        }
        public IActionResult ViewAllUser() {
            List<User> users = _userReposistory.GetAllUsers();
            return View("ViewAllUser",users);
        }
        public IActionResult ViewAllAdmin()
        {
            List<User> admins = _userReposistory.GetAllAdmin();
            return View("ViewAllAdmin", admins);
        }
        //Edit
        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            _userReposistory.UpdateUser(user);
            string viewName = TempData["viewName"] as string;
            return RedirectToAction(viewName);
        }
        public IActionResult EditAll(int id,string viewName)
        {
            var listRole = from r in _roleReposistory.GetAllRoles()
                           select new SelectListItem()
                           {
                               Text = r.Name,
                               Value = r.Id.ToString(),
                           };
            ViewBag.RoleId = listRole.ToList();
            TempData["viewName"] = viewName;

            return View("EditAll", _userReposistory.findUserByID(id));

        }
        //Delete
        public IActionResult DeleteAll(int id,string viewName)
        {
            _userReposistory.DeleteUser(id);
            return RedirectToAction(viewName);
        }

    }
}
