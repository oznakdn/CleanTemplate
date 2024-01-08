using Clean.WebRazorPages.Pages.Product.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clean.WebRazorPages.Pages.Product;

public class IndexModel : PageModel
{
    private readonly ProductService _productService;

    public IEnumerable<ProductsResponse> Products { get; set; }
    public IndexModel(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> OnGet()
    {
        var response = await _productService.GetProductsAsync();
        if(response.IsFailed)
        {
            return RedirectToPage("/Admin/Auth/Login");
        }
        Products = response.Values.ToList();
        return Page();
    }
}
