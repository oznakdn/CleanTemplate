namespace Clean.Application.Features.Commands.UserCommands.Register.Dtos;

public class RegisterRequest : IRequest<RegisterResponse>
{
    public virtual string? FirstName { get; set; }
    public virtual string? LastName { get; set; }
    public virtual string? Username { get; set; }
    public virtual string Email { get; set; }
    public virtual string PasswordHash { get; set; }
}
