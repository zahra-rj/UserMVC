using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using UserMVC.Models;

namespace UserMVC.Controllers
{
    public class CarController : Controller
    {


        public static List<Car> ListCar = new List<Car>
        {
            new Car {Id=1, Brand="Benz",Model="s5",Color="pink"},
            new Car {Id=2,Brand="BMW",Model="s5",Color="Blue"}
        };
        public async Task<IActionResult> List()
        {
            return View(ListCar);


        }
        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            ListCar = new List<Car>();
            return View(ListCar);
        }
    }
}
