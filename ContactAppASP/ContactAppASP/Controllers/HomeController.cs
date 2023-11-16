using Microsoft.AspNetCore.Mvc;

namespace ContactAppASP.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string number, string email)
        {
            ViewData["name"] = name;
            ViewData["number"] = number;
            ViewData["email"] = email;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}