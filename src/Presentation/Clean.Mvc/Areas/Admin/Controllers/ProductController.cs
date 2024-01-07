using Clean.Mvc.ClientServices;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
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

    public async Task<IActionResult> Edit(string id)
    {
        var products = await _productService.GetProductsAsync();
        var product = products.Values.SingleOrDefault(x => x.id == id);
        return View(product);
    }
}
