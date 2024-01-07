using Clean.WebRazorPages.Services;
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

    public async Task OnGet()
    {
        var response = await _productService.GetProductsAsync();
        Products = response.Values.ToList();
    }
}
