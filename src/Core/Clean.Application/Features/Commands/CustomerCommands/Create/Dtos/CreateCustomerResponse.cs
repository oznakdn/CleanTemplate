namespace Clean.Application.Features.Commands.CustomerCommands.Create.Dtos;

public class CreateCustomerResponse
{
    public bool Success { get; set; } = true;
    public List<string>? Errors { get; set; }
    public string Message { get; set; }
}
