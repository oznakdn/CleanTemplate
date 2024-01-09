namespace Clean.Blazor.Models.Auth;

//public record LoginRequest(string email, string password);

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
