using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserMVC.Models;
using UserMVC.Services;
using UserMVC.ViewModels;

namespace UserMVC.Controllers
{
   
    public class CarController : Controller
    {

    private readonly IUserService _userService;


        public async Task<VmCar> Tovmcar(Car car)
        {
            return new VmCar
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Color = car.Color,

                UserName =await _userService.GetNameById(car.Id),

            };
        }
        public async Task<List<VmCar>> Tovmcar(List<Car> car)
        {
            List<VmCar> li = new List<VmCar>();
            foreach (var item in car)
            {
                li.Add(await Tovmcar(item));
            }
            return li;
        }
        public static List<Car> ListCar = new List<Car>
        {
            new Car {Id=1, Brand="Benz",Model="s5",Color="pink",UserId=1},
            new Car {Id=2,Brand="BMW",Model="s5",Color="Blue", UserId=2}
        };

        public CarController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> List()
        {
            return View(Tovmcar(ListCar));

        }
        [HttpGet]
        public async Task<IActionResult> Insert()
        {
           
            Car car = new Car();
            ViewBag.Users = _userService.GetList() ;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Car car)
        {
            List<Car> sdgdsg = new List<Car>();
            sdgdsg.Add(car);
            car.Id = ListCar.OrderByDescending(c => c.Id).Select(c => c.Id).FirstOrDefault() + 1;
            ListCar.Add(car);
            return RedirectToAction("list");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Car car = ListCar.FirstOrDefault(c => c.Id == id);
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Car car)
        {
            Car oldcar = ListCar.FirstOrDefault(c => c.Id == car.Id);
            ListCar.Remove(oldcar);
            ListCar.Add(car);
            return RedirectToAction("list");

        }

        public async Task<IActionResult> Delete(int id)
        {
            Car car = ListCar.FirstOrDefault(c => c.Id == id);
            ListCar.Remove(car);
            return RedirectToAction("list");
        }






    }
}