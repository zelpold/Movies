using Microsoft.AspNetCore.Mvc;

namespace Movies.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
