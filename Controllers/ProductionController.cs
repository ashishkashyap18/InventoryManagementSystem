using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class ProductionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
