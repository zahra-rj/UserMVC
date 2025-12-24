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

    private readonly ICarService _carService;
    private readonly IUserService _userService;

        public CarController(ICarService carService,IUserService userService)
    {
        _carService = carService;
        _userService = userService;
    }
       
        

        public async Task<IActionResult> List()
        {
            await _carService.Initdata();
            var res = await _carService.GetList();
            return View(res);

        }
        [HttpGet]
        public async Task<IActionResult> Insert()
        {
           
            Car car = new Car();
            ViewBag.Users =await _userService.GetList() ;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Car car)
        {
            if (car.File == null || car.File.Length == 0)
                return BadRequest("فایلی انتخاب نشده است.");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", car.File.FileName);

            // ایجاد مسیر در صورت نبود پوشه
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            // ذخیره فایل به صورت Stream



            using (var stream = new FileStream(path, FileMode.Create))
            {
                await car.File.CopyToAsync(stream);
            }
            car.ImgPath = "/img/"+ car.File.FileName;
            await _carService.Insert(car);
            return RedirectToAction("list");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Car car = await _carService.Get(id);
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Car car)
        {
            await _carService.Update(car);
           
            return RedirectToAction("list");

        }

        public async Task<IActionResult> Delete(int id)
        {
           await _carService.Delete(id);
            return RedirectToAction("list");
        }



    }
}