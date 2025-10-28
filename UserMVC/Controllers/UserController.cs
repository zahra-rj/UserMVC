using Microsoft.AspNetCore.Mvc;
using UserMVC.Models;
//using UserMVC.Views.User;


namespace UserMVC.Controllers
{

    public class UserController : Controller
    {
        public static List<User> ListUsers = new List<User>
        {
             new User {Id=1 , Name = "ستاره", Email = "setareh@example.com", Age = 29 },
              new User { Id=2 ,  Name = "زهرا", Email = "zahra@example.com", Age = 28 }
        };

      
        
        public ActionResult List()
        {

           
          
            //var users = new List<User>
            //{
            //    new User {  Name = "ستاره", Email = "setareh@example.com", Age = 29 },
            //    new User {  Name = "زهرا", Email = "zahra@example.com", Age = 28 }

            //};
            return View(ListUsers.OrderBy(c=> c.Id).ToList());
        }

        [HttpGet]
        public ActionResult Insert()
        { 
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult Insert(User user)
        {
            user.Id = ListUsers.OrderByDescending(c=>c.Id).Select(c=>c.Id).FirstOrDefault() + 1;
            ListUsers.Add(user);
            return RedirectToAction("list");
        }

      public ActionResult Delete(int id)
        {
            User user= ListUsers.FirstOrDefault(c=>c.Id==id);
            ListUsers.Remove(user);
            return RedirectToAction("list");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            User user = ListUsers.FirstOrDefault(c=>c.Id==id);
            
            return View(user);
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            User Olduser= ListUsers.FirstOrDefault(c => c.Id == user.Id);
            ListUsers.Remove(Olduser);
            ListUsers.Add(user);
            return RedirectToAction("list");
        }

    }
}
