using AutoMapper;
using Clean.Application.Features.Queries.Customers.GetCustomers.Dtos;
using Clean.Domain.Entities;

namespace Clean.Application.Features.Queries.Customers.GetCustomers.Mapping;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<Customer,GetCustomersResponse>();
    }
}