using Clean.Application.Features.Queries.ProductQueries.Get.Dtos;

namespace Clean.Application.Features.Queries.ProductQueries.Get.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ProductResponse>();
    }
}
