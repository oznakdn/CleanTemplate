namespace Clean.WebRazorPages.Models.ProductModels;

public record ProductDetailResponse(string Id, string DisplayName, ProductMoney Money, ProductCategory Category, ProductInventory Inventory);

public record ProductMoney(string Currency, decimal Amount);
public record ProductCategory(string DisplayName);
public record ProductInventory(int Quantity, bool HasStock);