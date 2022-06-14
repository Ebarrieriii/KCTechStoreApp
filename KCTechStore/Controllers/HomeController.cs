using KCTechStore.Models;
using KCTechStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KCTechStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShoeService _shoeService;

        public HomeController(ILogger<HomeController> logger, IShoeService shoeService)
        {
            _logger = logger;
            _shoeService = shoeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}