using Microsoft.AspNetCore.Mvc;

namespace UserAndCourse.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
