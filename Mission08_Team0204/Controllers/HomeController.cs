using Microsoft.AspNetCore.Mvc;
//using Mission08_Team0204.Models;
using System.Diagnostics;

namespace Mission08_Team0204.Controllers
{ //Testing
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
