using UserMVC.Models;

namespace UserMVC.Services
{
    public interface IUserService
    {
        Task<List<User>> GetList();
        Task InitData();
        Task Insert(User user);
        Task delete(int id);
        Task<User> Get(int id);
        Task Update(User user);
        Task<string> GetNameById(int id);
         Task Log(User user);
    }
}
