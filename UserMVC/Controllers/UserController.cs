using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserMVC.DB;
using UserMVC.Models;
using UserMVC.Services;
//using UserMVC.Views.User;


namespace UserMVC.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// اکشن نمایش لیست
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> List()
        {
            await _userService.InitData();
            return View(await _userService.GetList());
        }

        [HttpGet]
        public ActionResult Insert()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public async Task<ActionResult> Insert(User user)
        {
           
            await _userService.Insert(user);

            return RedirectToAction("list");
        }

        public async Task<ActionResult> Delete(int id)
        {
           await _userService.delete(id);
            return RedirectToAction("list");

        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var user =await _userService.Get(id);

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Update(User user)
        {
           await _userService.Update(user);
            return RedirectToAction("list");
        }

    }
}
