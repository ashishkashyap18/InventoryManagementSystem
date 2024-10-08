using ManagementSystem.Interface;
using ManagementSystem.Models;
using ManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Controllers
{
    public class ProductionController : Controller
    {
        private readonly IProductionServices _production;
        private readonly IProductServices _product;
        private readonly IUnitServices _unit;
        private readonly IEmployeeServices _employee;

        public ProductionController(IProductionServices production, IProductServices product, IUnitServices unit , IEmployeeServices employee)
        {
            _production = production;
            _product = product;
            _unit = unit;
            _employee = employee;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var units = await _unit.GetAllUnits();
            var product = await _product.GetAllProduct();
            var employee = await _employee.GetAllEmployees();
            ViewBag.Units = units;
            ViewBag.Products = product;
            ViewBag.Employees = employee;
            return View();
        }       
    }
}
