using Clean.Domain.Products.Enums;

namespace Clean.WebRazorPages.Models.ProductModels;

public record UpdateProductRequest(string Id, string? DisplayName, Currency? Currency, decimal? Amount, string? CategoryName);

