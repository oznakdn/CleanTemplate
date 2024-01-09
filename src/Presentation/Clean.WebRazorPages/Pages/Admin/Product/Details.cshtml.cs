using Clean.WebRazorPages.Filters;
using Clean.WebRazorPages.Models.ProductModels;
using Clean.WebRazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clean.WebRazorPages.Pages.Admin.Product;

[AuthorizationFilter]
public class DetailsModel : PageModel
{

    private readonly ProductService _productService;
    public DetailsModel(ProductService productService)
    {
        _productService = productService;
    }

    public ProductDetailResponse ProductDetailResponse { get; set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        var response = await _productService.GetProductDetailAsync(id);
        if(!response.IsSuccess)
        {
            return RedirectToPage("/AccessDenied");
        }

        ProductDetailResponse = response.Value;
        return Page();
    }
}
