namespace Clean.Application.Features.Product.Dtos;

public class ProductResponse
{
    public List<ProductDto> Products { get; set; }
}

public class ProductDto
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

