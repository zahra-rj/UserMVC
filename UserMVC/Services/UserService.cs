using UserMVC.DB;
using UserMVC.Models;

namespace UserMVC.Services
{
    public class UserService : IUserService
    {
        public UserService() { }

        public async Task InitData()
        {
            if (Database.Users == null)
            {
                Database.Users = new List<User>();
            }
            if (Database.Users.Count == 0)
            {
                Database.Users.Add(new User { Name = "ستاره", Email = "setareh@example.com", Age = 29, Id = 1 });
                Database.Users.Add(new User { Name = "زهرا", Email = "zahra@example.com", Age = 28, Id = 2 });
            }

        }
        public async Task<List<User>> GetList()
        {
            return Database.Users;
        }
        public async Task Insert(User user)
        {
            user.Id = Database.Users.OrderByDescending(c => c.Id).Select(c => c.Id).FirstOrDefault() + 1;
            Database.Users.Add(user);
        }
        public async Task delete(int id)
        {
            User user =await Get(id);
            Database.Users.Remove(user);
        }
        public async Task<User> Get(int id)
        {
            return Database.Users.FirstOrDefault(c => c.Id == id);
        }
        public async Task Update(User user)
        {
            User Olduser = await Get(user.Id);
            Database.Users.Remove(Olduser);
            Database.Users.Add(user);
        }

        public async Task<string> GetNameById(int id)
        {


            var res = await Get(id);
            return res.Name;
        }

        public async Task Log(User user)
        {
            //opdsihghiohesoi
        }

    }
}
