using Clean.Application.Features.Commands.CustomerCommands.Create.Dtos;
using Clean.Domain.Entities.Customer;

namespace Clean.Application.Features.Commands.CustomerCommands.Create.Mapping;

public class CreateCustomerMapping : Profile
{
    public CreateCustomerMapping()
    {
        CreateMap<CreateCustomerRequest, Customer>();
    }
}
