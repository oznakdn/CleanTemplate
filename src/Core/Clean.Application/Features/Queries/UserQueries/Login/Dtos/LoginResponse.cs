namespace Clean.Application.Features.Queries.UserQueries.Login.Dtos;

public class LoginResponse
{
    public string? Token { get; set; }
    public DateTime? TokenExpiredDate { get; set; }
    public List<string>? Errors { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; } = true;
}
