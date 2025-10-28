using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using UserMVC.Models;
using UserMVC.ViewModels;

namespace UserMVC.Controllers
{
    public class CarController : Controller
    {
        public VmCar Tovmcar(Car car)
        {
            return new VmCar
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Color = car.Color,

                UserName = UserController.ListUsers.Where(c => c.Id == car.UserId).FirstOrDefault().Name,

            };
        }
        public List<VmCar> Tovmcar(List<Car> car)
        {
            List<VmCar> li = new List<VmCar>(); 
            foreach (var item in car)
            {
                li.Add(Tovmcar(item));
            }
            return li;
        }
        public static List<Car> ListCar = new List<Car>
        {
            new Car {Id=1, Brand="Benz",Model="s5",Color="pink",UserId=1},
            new Car {Id=2,Brand="BMW",Model="s5",Color="Blue", UserId=2}
        };
        public async Task<IActionResult> List()
        {
            return View(Tovmcar(ListCar));

        }
        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            Car car = new Car();
            ViewBag.Users = UserController.ListUsers;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Car car)
        {
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
            Car oldcar= ListCar.FirstOrDefault(c=> c.Id==car.Id);
            ListCar.Remove(oldcar);
            ListCar.Add(car);
            return RedirectToAction("list");

        }

        public async Task<IActionResult> Delete  (int id)
        {
            Car car = ListCar.FirstOrDefault(c => c.Id == id);
            ListCar.Remove(car);
            return RedirectToAction("list");
        }






    }
}