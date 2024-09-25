using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class UnitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
