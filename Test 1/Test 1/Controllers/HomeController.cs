using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using Test_1.Models;

namespace Test_1.Controllers
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
            ViewData["Message"] = "Message from ViewData";
            ViewBag.Message2 = "Lop N03 dep trai";
            TempData["Message3"] = "Tối nay đi ngủ sớm";
            return RedirectToAction("Privacy");
        }

        public IActionResult Privacy()
        {
   
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
