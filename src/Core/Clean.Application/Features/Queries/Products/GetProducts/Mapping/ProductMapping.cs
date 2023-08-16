namespace Clean.Application.Features.Queries.Products.GetProducts.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ProductResponse>();
    }
}
