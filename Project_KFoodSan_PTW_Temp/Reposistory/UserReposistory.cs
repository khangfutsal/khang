using Microsoft.AspNetCore.Mvc;
using Project_KFoodSan_PTW_Temp.Models;
namespace Project_KFoodSan_PTW_Temp.Reposistory
{
    public interface IUserReposistory
    {
        public bool CreateUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int userID);
        
        public bool CheckSameName(string name);
        public bool CheckSamePassword(string password);
        public int CheckRoleUser(string userName);
        public List<User> GetAllUsers();
        public List<User> GetAllAdmin();
        public User findUserByID(int userID);
    }
    public class UserReposistory : IUserReposistory
    {
        public KfoodSanContext _ctx;
        public UserReposistory(KfoodSanContext ctx)
        {
            _ctx = ctx;
        }

		public int CheckRoleUser(string userName)
		{
            int userRole;
			User c = _ctx.Users.Where(x => x.Username == userName).FirstOrDefault();
			if (c != null)
			{
                userRole = (int)c.RoleId;
                return userRole;
			}
            return 0;
		}

		public bool CheckSameName(string name)
        {
            User c = _ctx.Users.Where(x=>x.Username.Trim() == name.Trim()).FirstOrDefault();
            if(c != null)
            {
                return true;
            }
            return false;
        }

		public bool CheckSamePassword(string password)
		{
			User c = _ctx.Users.Where(x => x.Password.Trim() == password.Trim()).FirstOrDefault();
			if (c != null)
			{
				return true;
			}
			return false;
		}

		public bool CreateUser(User user)
        {
            user.RoleId = 2;//User
            _ctx.Add(user);
            _ctx.SaveChanges();
            return true;
        }

        public bool DeleteUser(int userID)
        {
            User c = _ctx.Users.Where(x=>x.Id== userID).FirstOrDefault();
            if (c != null)
            {
                _ctx.Users.Remove(c);
                _ctx.SaveChanges();
                return true;
            }
            return false;

        }

        public User findUserByID(int userID)
        {
            User u = _ctx.Users.Where(x=>x.Id== userID).FirstOrDefault();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public List<User> GetAllAdmin()
        {
            return _ctx.Users.Where(x => x.RoleId.Equals(1)).ToList();
        }

        public List<User> GetAllUsers()
        {
            return _ctx.Users.Where(x=>x.RoleId.Equals(2)).ToList();
        }
        

        public bool UpdateUser(User user)
        {
            User u = _ctx.Users.Where(x=>x.Id == user.Id).FirstOrDefault();
            if (u != null)
            {
                _ctx.Entry(u).CurrentValues.SetValues(user);
                _ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
