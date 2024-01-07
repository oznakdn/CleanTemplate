using Clean.Mvc.ClientServices;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetProductsAsync();
            return View(result.Values);
        }
    }
}
