namespace Clean.Application.Features.Commands.Customers.Add.Dtos;

public class AddCustomerResponse
{
    public bool Success { get; set; } = true;
    public List<string>? Messages { get; set; }
}
