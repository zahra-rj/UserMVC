using UserMVC.DB;
using UserMVC.Models;
using UserMVC.ViewModels;

namespace UserMVC.Services
{
    public class CarService : ICarService

    {
        private readonly IUserService _userService;

        public CarService(IUserService userService)
        {
            _userService = userService;
        }
       
        public async Task Delete(int id)
        {
            var car = await Get(id);
            Database.Cars.Remove(car);
        }

        public async Task<Car> Get(int id)
        {
            return Database.Cars.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<VmCar>> GetList()
        {
            return await Map(Database.Cars);
        }

        public async Task Initdata()
        {
           await _userService.InitData();
            if (Database.Cars == null)
            {
                Database.Cars = new List<Car>();
            }
            if (Database.Cars.Count == 0)
            {
                Database.Cars.Add(new Car { Id = 1, Brand = "Benz", Model = "s5", Color = "pink", UserId = 1 , ImgPath = "/img/img.jpg" });
                Database.Cars.Add(new Car { Id = 2, Brand = "BMW", Model = "s5", Color = "Blue", UserId = 2 , ImgPath = "/img/img.jpg" });
            }
        }

        public async Task Insert(Car car)
        {
            car.Id = Database.Cars.OrderByDescending(c => c.Id).Select(c => c.Id).FirstOrDefault() + 1;
            Database.Cars.Add(car);
        }

        public async Task Update(Car car)
        {
            Car oldcar = await Get(car.Id);
            Database.Cars.Remove(oldcar);
            Database.Cars.Add(car);
        }

        public async Task<VmCar> Map(Car car)
        {
            return new VmCar
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Color = car.Color,
                ImgPath = car.ImgPath,
                UserName = await _userService.GetNameById(car.UserId),

            };
        }
        public async Task<List<VmCar>> Map(List<Car> car)
        {
            List<VmCar> li = new List<VmCar>();
            foreach (var item in car)
            {
                li.Add(await Map(item));
            }
            return li;
        }

    }
}
