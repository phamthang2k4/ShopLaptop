using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test_2.Models;

namespace Test_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Privacy(Login u)
        {
            if (u.userName == "Peter" && u.password ==
            "pass@123")
            {
                string msg = "Welcome " + u.userName;
                return Content(msg);
            }
            else { return View(); }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
