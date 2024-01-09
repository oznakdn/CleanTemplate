using Clean.WebRazorPages.Models.ProductModels;
using Clean.WebRazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clean.WebRazorPages.Pages.Admin.Product;

public class InsertModel : PageModel
{
    private readonly ProductService _productService;
    public InsertModel(ProductService productService)
    {
        _productService = productService;
    }

    [BindProperty]
    public InsertProductRequest InsertProductRequest { get; set; }

    [BindProperty]
    public IFormFile[] Files { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        foreach (var file in Files)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
            InsertProductRequest.Images.Add(new ProductImage { ImageName = file.FileName, ImageSize = file.Length.ToString() });
            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
        }

        var response = await _productService.InsertProductAsync(InsertProductRequest);
        if (!response.IsSuccess)
        {
            return RedirectToPage("/Error");
        }

        return RedirectToAction("/Admin/Product/Index");
    }
}
