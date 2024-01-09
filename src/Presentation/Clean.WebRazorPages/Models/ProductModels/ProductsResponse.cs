namespace Clean.WebRazorPages.Models.ProductModels;

public record ProductsResponse(string Id, string DisplayName, string Currency, decimal Price, string Category, List<ProductImage> Images);
public record ProductImage(string ImageName, string ImageSize);
