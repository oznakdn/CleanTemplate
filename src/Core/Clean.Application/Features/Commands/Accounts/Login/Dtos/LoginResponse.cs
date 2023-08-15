namespace Clean.Application.Features.Commands.Accounts.Login.Dtos;

public class LoginResponse
{
    public string? Token { get; set; }
    public DateTime? TokenExpiredDate { get; set; }
    public List<string>? ErrorMessages { get; set; }
}
