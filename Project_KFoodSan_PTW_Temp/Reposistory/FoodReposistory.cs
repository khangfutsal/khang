using Microsoft.AspNetCore.Mvc;
using Project_KFoodSan_PTW_Temp.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
namespace Project_KFoodSan_PTW_Temp.Reposistory
{
    public interface IFoodReposistory
    {
        public bool CreateFood(Food food);
        public bool UpdateFood(Food food);
        public bool DeleteFood(int id);
        public List<Food> GetAllFood();
        public Food FindFoodByID(string id);

        public List<Food> GetFoodCombo();
    }
    public class FoodReposistory : IFoodReposistory
    {
        public KfoodSanContext _ctx;
        public FoodReposistory(KfoodSanContext ctx)
        {
            _ctx = ctx;
        }
        public bool CreateFood(Food food)
        {
            _ctx.Foods.Add(food);
            _ctx.SaveChanges();
            return true;
        }

        public bool DeleteFood(int id)
        {
            Food f = _ctx.Foods.Where(x => x.Id == id).FirstOrDefault();
            if (f != null)
            {
                _ctx.Foods.Remove(f);
                _ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public Food FindFoodByID(string id)
        {

            if (int.TryParse(id, out int foodID))
            {
                Food f = _ctx.Foods.Where(x => x.Id == foodID).FirstOrDefault();
                if (f != null)
                {
                    return f;
                }
            }
            return null;

        }

        public List<Food> GetAllFood()
        {
            return _ctx.Foods.Include(x => x.Category).ToList();
        }

        public List<Food> GetFoodCombo()
        {
            return _ctx.Foods.Where(x => x.Name.StartsWith("Combo")).ToList();
        }

        public bool UpdateFood(Food food)
        {
            Food f = _ctx.Foods.Where(x => x.Id == food.Id).FirstOrDefault();
            if (f != null)
            {
                _ctx.Entry(f).CurrentValues.SetValues(food);
                _ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
