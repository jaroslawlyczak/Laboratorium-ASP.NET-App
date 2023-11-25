using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab1.Controllers
{
<<<<<<< HEAD
    public enum Operators
    {
        ADD, SUB, MUL, DIV
    }

=======
>>>>>>> 5e93975df2b1082136fc0ddb9f1aa7993be4ec53
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

        public IActionResult Privacy()
        {
            return View();
        }

<<<<<<< HEAD
        public IActionResult About([FromQuery(Name = "app-author")] string author)
        {
            // string author = Request.Query["author"];
            ViewBag.Author = author;
            return View();
        }

        public IActionResult Calculator([FromQuery(Name = "operator")] Operators op, double? a, double? b)
        {
            if (a == null || b == null) { return View("Error"); }

            switch (op)
            {
                case Operators.ADD: ViewBag.Result = a + b; break;
                case Operators.SUB: ViewBag.Result = a - b; break;
                case Operators.MUL: ViewBag.Result = a * b; break;
                case Operators.DIV: ViewBag.Result = a / b; break;
            }

            return View();
        }

=======
>>>>>>> 5e93975df2b1082136fc0ddb9f1aa7993be4ec53
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}