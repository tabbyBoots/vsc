using Microsoft.AspNetCore.Mvc;

namespace mvcdemo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return Content("NOT AUTHERIZED");
        }
    }
}