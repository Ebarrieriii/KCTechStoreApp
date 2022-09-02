using KCTechStore.Models;
using KCTechStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KCTechStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IComputerService _computerService;

        public HomeController(ILogger<HomeController> logger, IComputerService computerService)
        {
            this._logger = logger;
            this._computerService = computerService;
        }

        public IActionResult Index()
        {
            var shoes = _computerService.GetComputers();
            //_computerService.PostComputers();
            return View(shoes);
        }

        //Create GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Create POST
        [HttpPost]
        public void Create(ShoeViewModel shoeData)
        {
            _computerService.PostComputers(shoeData);
        }

        //Edit GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var computerInfo = _computerService.GetComputers().Where(m => m.ShoeId == id).FirstOrDefault();

            return View(computerInfo);
        }

        //Edit POST
        //[HttpPost]
        //public IActionResult Edit()
        //{

        //}

        public IActionResult Privacy()
        {
            return View();
        }
    }
}