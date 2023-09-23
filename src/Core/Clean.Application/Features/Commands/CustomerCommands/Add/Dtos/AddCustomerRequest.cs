namespace Clean.Application.Features.Commands.CustomerCommands.Add.Dtos;

public class AddCustomerRequest : IRequest<AddCustomerResponse>
{
    public string FullName { get; set; }
    public string Email { get; set; }
}
