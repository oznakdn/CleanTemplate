namespace Clean.Identity.Jwt;

public class JwtSetting
{
    public bool? ValidateIssuer { get; set; }
    public bool? ValidateAudience { get; set; }
    public bool? ValidateIssuerSigningKey { get; set; }
    public bool? ValidateLifetime { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? SecurityKey { get; set; }
}
