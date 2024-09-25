using ManagementSystem.Interface;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            this.employeeServices = employeeServices;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await employeeServices.GetAllEmployees();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await employeeServices.CreateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) {
            var employee = await employeeServices.GetEmployeeById(id);
            if(employee != null)
            {
                return View(employee);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Employee employee)
        {       
            if(id != employee.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid) {
                var response = await employeeServices.UpdateEmployee(employee);
                if (response)
                {
                 return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await employeeServices.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
