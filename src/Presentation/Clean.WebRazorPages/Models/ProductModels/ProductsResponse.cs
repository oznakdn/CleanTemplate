namespace Clean.WebRazorPages.Models.ProductModels;

public record ProductsResponse(string Id, string DisplayName, string Currency, decimal Price, string Category, List<ProductImage> Images);


public class ProductImage
{
    public string ImageName { get; set; }
    public string ImageSize { get; set; }
}
