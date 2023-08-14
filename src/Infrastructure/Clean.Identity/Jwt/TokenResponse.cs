namespace Clean.Identity.Jwt;

public record TokenResponse(string Token, DateTime TokenExpiredDate);
