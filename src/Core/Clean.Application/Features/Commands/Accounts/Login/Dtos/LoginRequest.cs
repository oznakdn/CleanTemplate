namespace Clean.Application.Features.Commands.Accounts.Login.Dtos;

public class LoginRequest:IRequest<LoginResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
