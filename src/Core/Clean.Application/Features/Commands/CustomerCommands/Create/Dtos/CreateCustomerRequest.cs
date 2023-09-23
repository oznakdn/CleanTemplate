namespace Clean.Application.Features.Commands.CustomerCommands.Create.Dtos;

public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
{
    public string FullName { get; set; }
    public string Email { get; set; }
}
