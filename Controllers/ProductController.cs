using ManagementSystem.Interface;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IUnitServices _unitServices;

        public ProductController(IProductServices productServices, IUnitServices unitServices)
        {
            _productServices = productServices;
            _unitServices = unitServices;
        }
        public async Task<IActionResult> Index()
        {
            var productList = await _productServices.GetAllProduct();
            return View(productList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var units = await _unitServices.GetAllUnits();
            ViewBag.Units = units;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productServices.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            var units = await _unitServices.GetAllUnits();
            ViewBag.Units = units;
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productServices.GetProductById(id);
            var units = await _unitServices.GetAllUnits();
            ViewBag.Units = units;
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productServices.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            var units = await _unitServices.GetAllUnits();
            ViewBag.Units = units;
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _productServices.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
