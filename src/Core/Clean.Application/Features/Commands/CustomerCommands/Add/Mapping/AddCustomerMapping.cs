using Clean.Application.Features.Commands.CustomerCommands.Add.Dtos;

namespace Clean.Application.Features.Commands.CustomerCommands.Add.Mapping;

public class AddCustomerMapping : Profile
{
    public AddCustomerMapping()
    {
        CreateMap<AddCustomerRequest, Customer>();
    }
}
