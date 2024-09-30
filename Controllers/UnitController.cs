using ManagementSystem.Interface;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitServices _unitServices;

        public UnitController(IUnitServices unitServices)
        {
            _unitServices = unitServices;
        }
        public async Task<IActionResult> Index()
        {
            var units = await _unitServices.GetAllUnits();
            return View(units);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Unit unit)
        {
            if (ModelState.IsValid)
            {
                await _unitServices.CreateUnit(unit);
                return RedirectToAction(nameof(Index));
            }
            return View(unit);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var unit = await _unitServices.GetUnitById(id);
            return View(unit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Unit unit)
        {
            if (ModelState.IsValid) {
                await _unitServices.UpdateUnit(unit);
                return RedirectToAction(nameof(Index));
            }
            return View(unit);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitServices.DeleteUnit(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
