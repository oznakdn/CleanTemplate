using AutoMapper;
using Clean.Application.Features.Queries.Products.GetProducts.Dtos;

namespace Clean.Application.Features.Queries.Products.GetProducts.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Domain.Entities.Product, ProductResponse>();
    }
}
