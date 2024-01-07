namespace Clean.Mvc.Models.Product;

//public record GetProductsModel(string displayName, decimal price,string currency, string category);

public class GetProductsModel
{
    public string displayName {  get; set; }
    public decimal price { get; set; }
    public string currency { get; set; }
    public string category { get; set; }
    public List<ProductImage> images { get; set; } = new();
}

public class ProductImage
{
    public string imageName { get; set; }
    public string imageSize { get; set; }
}