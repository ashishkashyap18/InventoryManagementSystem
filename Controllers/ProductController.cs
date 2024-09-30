using ManagementSystem.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        public async Task<IActionResult> Index()
        {
            var productList = await _productServices.GetAllProduct();
            return View(productList);
        }
    }
}
