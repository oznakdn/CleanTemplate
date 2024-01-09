using Clean.WebRazorPages.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Clean.WebRazorPages.Filters;
using Clean.WebRazorPages.Models.ProductModels;
using Microsoft.AspNetCore.Mvc;

namespace Clean.WebRazorPages.Pages.Admin.Product;

[AuthorizationFilter]
public class IndexModel : PageModel
{
    private readonly ProductService _productService;

    public IndexModel(ProductService productService)
    {
        _productService = productService;
        Products = new();
    }

    public List<ProductsResponse> Products { get; set; }
    public async Task<IActionResult> OnGetAsync()
    {
         var result = await _productService.GetProductsAsync();
        if(!result.IsSuccess)
        {
            return RedirectToPage("/Error");
        }
        Products = result.Values.ToList();
        return Page();
    }
}
