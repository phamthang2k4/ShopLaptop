using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebBanVali.Models;
using X.PagedList;


namespace WebBanVali.Controllers
{
    public class HomeController : Controller
    {
        MasterContext db = new MasterContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;
            int pageSize = 12;
            var lstsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.MaSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }

        public IActionResult ProductDetail(TDanhMucSp sanPham)
        {
            return View(sanPham);
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
