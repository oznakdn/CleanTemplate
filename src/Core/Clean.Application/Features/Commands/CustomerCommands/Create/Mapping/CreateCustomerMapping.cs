using Clean.Application.Features.Commands.CustomerCommands.Create.Dtos;

namespace Clean.Application.Features.Commands.CustomerCommands.Create.Mapping;

public class CreateCustomerMapping : Profile
{
    public CreateCustomerMapping()
    {
        CreateMap<CreateCustomerRequest, Customer>();
    }
}
