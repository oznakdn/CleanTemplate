namespace Clean.Application.Features.Commands.UserCommands.Register.Dtos;

public class RegisterResponse
{
    public string? Message { get; set; }
    public List<string>? Errors { get; set; }
}
