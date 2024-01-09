using Clean.Domain.Products.Enums;

namespace Clean.WebRazorPages.Models.ProductModels;



public class InsertProductRequest
{
    public string DisplayName { get; set; }
    public Currency currency { get; set; }
    public decimal Amount { get; set; }
    public string CategoryName { get; set; }
    public int Quantity { get; set; }
    public List<ProductImage> Images { get; set; } = new();

}