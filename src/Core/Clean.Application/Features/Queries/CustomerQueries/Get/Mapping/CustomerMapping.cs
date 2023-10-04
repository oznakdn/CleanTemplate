using Clean.Application.Features.Queries.CustomerQueries.Get.Dtos;
using Clean.Domain.Entities.Customer;

namespace Clean.Application.Features.Queries.CustomerQueries.Get.Mapping;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<Customer,GetCustomersResponse>();
    }
}