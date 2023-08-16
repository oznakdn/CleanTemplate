namespace Clean.Application.Features.Commands.Customers.Add.Mapping;

public class AddCustomerMapping : Profile
{
    public AddCustomerMapping()
    {
        CreateMap<AddCustomerRequest, Customer>();
    }
}
