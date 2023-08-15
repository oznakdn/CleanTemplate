using AutoMapper;
using Clean.Application.Features.Product.Dtos;


namespace Clean.Application.Features.Product.Mapping;

public class ProductMapping:Profile
{
    public ProductMapping()
    {
        CreateMap<Clean.Domain.Entities.Product, ProductResponse>();
    }
}
