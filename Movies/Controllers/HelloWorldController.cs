using Microsoft.AspNetCore.Mvc;

namespace Movies.Controllers
{
    public class HelloWorldController : Controller
    {
        public string Index()
        {
            //return View();
            return "This is my default action...";
        }
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}