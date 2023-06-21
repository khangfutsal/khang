using Microsoft.AspNetCore.Mvc;
using Project_KFoodSan_PTW_Temp.Models;

namespace Project_KFoodSan_PTW_Temp.Reposistory
{
    public interface ICountryReposistory
    {
        public List<Country> getAllCountry();
    }
    public class CountryReposistory : ICountryReposistory
    {
        KfoodSanContext _ctx;
        public CountryReposistory(KfoodSanContext ctx)
        {
            _ctx = ctx;
        }
        public List<Country> getAllCountry()
        {
            return _ctx.Countries.ToList(); 
        }
    }
}
