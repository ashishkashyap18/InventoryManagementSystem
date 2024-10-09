using ManagementSystem.Interface;
using ManagementSystem.Models;
using ManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class ProductionController : Controller
    {
        private readonly IProductionServices _production;
        private readonly IProductServices _product;
        private readonly IUnitServices _unit;
        private readonly IEmployeeServices _employee;

        public ProductionController(IProductionServices production, IProductServices product, IUnitServices unit, IEmployeeServices employee)
        {
            _production = production;
            _product = product;
            _unit = unit;
            _employee = employee;
        }

        public async Task<IActionResult> Index()
        {
            var productions = await _production.GetAllProductions();
            return View(productions);
        }

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<Production> productions)
        {
            if (productions != null && ModelState.IsValid)
            {
                foreach (var production in productions)
                {
                    _production.CreateProduction(production);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Units = await _unit.GetAllUnits();
            ViewBag.Products = await _product.GetAllProduct();
            ViewBag.Employees = await _employee.GetAllEmployees();
            return View(productions);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var production = await _production.GetProductionById(id);
            if (production != null)
            {
                ViewBag.Employees = await _employee.GetAllEmployees();
                ViewBag.Products = await _product.GetAllProduct();
                return View(production);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Production production)
        {
            if (ModelState.IsValid)
            {
                var success = await _production.UpdateProduction(production);
                if (success)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _production.DeleteProduction(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
