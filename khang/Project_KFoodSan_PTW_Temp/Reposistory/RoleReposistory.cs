using Microsoft.AspNetCore.Mvc;
using Project_KFoodSan_PTW_Temp.Models;

namespace Project_KFoodSan_PTW_Temp.Reposistory
{
    public interface IRoleReposistory
    {
        public bool CreateRole(Role role);
        public bool DeleteRole(int id);
        public bool UpdateRole(Role role);
        public List<Role> GetAllRoles();
    }
    public class RoleReposistory : IRoleReposistory
    {
        private KfoodSanContext _ctx;

        public RoleReposistory(KfoodSanContext ctx) {
            _ctx = ctx;
        }

        public bool CreateRole(Role role)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRole(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAllRoles()
        {
            return _ctx.Roles.ToList();
        }

        public bool UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
