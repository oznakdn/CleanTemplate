using Clean.Domain.Products.Enums;
using Clean.WebRazorPages.Models.ProductModels;
using Clean.WebRazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clean.WebRazorPages.Pages.Admin.Product;

public class EditModel : PageModel
{

    private readonly ProductService _productService;
    public EditModel(ProductService productService)
    {
        _productService = productService;
    }

    [BindProperty]
    public UpdateProductRequest UpdateProductRequest { get; set; }

    public async Task OnGet(string id)
    {
        var response = await _productService.GetProductDetailAsync(id);
        ProductDetailResponse product = response.Value;
        UpdateProductRequest = new(
            product.Id,
            product.DisplayName,
            (Currency)Enum.Parse(typeof(Currency), product.Money.Currency, true),
            product.Money.Amount,
            product.Category.DisplayName
           );

    }

    public async Task<IActionResult> OnPostAsync()
    {
        var result = await _productService.UpdateProductAsync(UpdateProductRequest);
        if (!result.IsSuccess)
        {
            return RedirectToPage("/Admin/Auth/Login");
        }

        return RedirectToPage("/Admin/Product/Index");
    }
}
