using Microsoft.AspNetCore.Mvc;



namespace UserMVC.Controllers
{
    public class UserController : Controller
    {
        public ActionResult List()
        {
            return View();
        }
    }
}
