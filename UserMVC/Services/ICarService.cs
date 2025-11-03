using UserMVC.Models;
using UserMVC.ViewModels;

namespace UserMVC.Services
{
    public interface ICarService
    {
        Task<List<VmCar>> GetList();
        Task Initdata();
        Task Insert(Car car);

        Task Update(Car car);
        Task Delete(int id);

        Task<Car> Get(int id);
        
    }
}
