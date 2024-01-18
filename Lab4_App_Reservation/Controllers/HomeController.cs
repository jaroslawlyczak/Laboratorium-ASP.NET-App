using Lab4_App_Reservation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab4_App_Reservation.Controllers
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

            ViewData["Count"] = HttpContext.Request.Cookies[LastVisitCookie.VisitCountCookie] ?? "1";
            ViewData["Visit"] = Response.HttpContext.Items[LastVisitCookie.CookieName];
            return View();
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