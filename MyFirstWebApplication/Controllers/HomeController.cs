using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstWebApplication.Models;
using MyFirstWebApplication.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public JsonFileCakeService CakeService;
        public static IEnumerable<Cake> Cakes { get; private set; }

        public HomeController(ILogger<HomeController> logger,
            JsonFileCakeService cakeService)
        {
            _logger = logger;
            CakeService = cakeService;
        }

        public IActionResult Index()
        {
            Cakes = CakeService.GetProducts();
            return View(Cakes);
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
