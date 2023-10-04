using Clean.Application.Features.Queries.ProductQueries.Get.Dtos;
using Clean.Domain.Entities.Product;

namespace Clean.Application.Features.Queries.ProductQueries.Get.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ProductResponse>();
    }
}
