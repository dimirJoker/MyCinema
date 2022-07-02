using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCinema.Models;
using MyCinema.Services;
using System.Diagnostics;

namespace MyCinema.Controllers
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
            MoviesTableActions tableAction = new();

            return View(tableAction.GetAllMovies());
            //return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}