using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_KFoodSan_PTW_Temp.Models;
using System.ComponentModel.DataAnnotations;
namespace Project_KFoodSan_PTW_Temp.Reposistory
{
    public interface ICategoryReposistory
    {
        public bool Create(Category category);
        public List<Category> GetAllCategories();
        public bool Delete(int id);
        public bool Update(Category category);
        public Category CategoryGetById(int id);
        public bool checkCategoryName(string categoryName);
    }
    public class CategoryReposistory : ICategoryReposistory
    {
        private KfoodSanContext _ctx;
        public CategoryReposistory(KfoodSanContext ctx)
        {
            _ctx = ctx;
        }
        public List<Category> GetAllCategories()
        {
            return _ctx.Categories.Include(x=>x.Foods).ToList();
        }

        public bool Create(Category category)
        {
            _ctx.Add(category);
            _ctx.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Category c = _ctx.Categories.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                _ctx.Remove(c);
                _ctx.SaveChanges();
                return true;
            }
            return false;
        }


        public bool Update(Category category)
        {
            Category c = _ctx.Categories.Where(x => x.Id == category.Id).FirstOrDefault();
            if (c != null)
            {
                _ctx.Entry(c).CurrentValues.SetValues(category);
                _ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public Category CategoryGetById(int id)
        {
            Category c = _ctx.Categories.Where(x => x.Id == id).FirstOrDefault();
            return c;
        }
        public bool checkCategoryName(string CategoryName)
        {
            Category c = _ctx.Categories.Where(x => x.CategoryName == CategoryName).FirstOrDefault();
            if (c != null)
            {
                return true;
            }
            return false;

        }
    }
}
