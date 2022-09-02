using Microsoft.AspNetCore.Mvc;

namespace KCTechStore.Controllers
{
    public class ComputerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
