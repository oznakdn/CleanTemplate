namespace Clean.Application.Features.Queries.UserQueries.Login.Dtos;

public class LoginRequest : IRequest<LoginResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
