namespace Clean.Identity.Jwt.Handler;

public class JwtHandler : IJwtHandler
{
    private readonly JwtSetting _settings;
    public JwtHandler(IOptions<JwtSetting> settings)
    {
        _settings = settings.Value;
    }
   

    public TokenResponse GenerateToken<TUser, TKey>(TUser user, int ExpireTime, ExpireType expireType) where TUser : UserIdentity<TKey>
    {
        var securityKey = _settings.ValidateIssuerSigningKey == true ? new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecurityKey!)) : null;
        DateTime _expires = DateTime.Now;


        switch (expireType)
        {
            case ExpireType.Seconds:
                _expires.AddSeconds(ExpireTime);
                break;
            case ExpireType.Minutes:
                _expires.AddMinutes(ExpireTime);
                break;
            case ExpireType.Hours:
                _expires.AddHours(ExpireTime);
                break;
            case ExpireType.Days:
                _expires.AddDays(ExpireTime);
                break;
            case ExpireType.Months:
                _expires.AddMonths(ExpireTime);
                break;
        }

        ClaimsIdentity _claimsIdentity = new ClaimsIdentity(new List<Claim>
        {
            new Claim (ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim (ClaimTypes.Email,user.Email),
            new Claim (ClaimTypes.Role,user.Role.RoleTitle)
        });

        SigningCredentials _signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        SecurityTokenDescriptor _tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _settings.ValidateIssuer == true ? _settings.Issuer : null,
            Audience = _settings.ValidateAudience == true ? _settings.Audience : null,
            Expires = _settings.ValidateLifetime == true ? _expires : null,
            Subject = _claimsIdentity,
            SigningCredentials = _signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var createdToken = tokenHandler.CreateToken(_tokenDescriptor);
        var writedToken = tokenHandler.WriteToken(createdToken);

        return new TokenResponse(writedToken, _expires);
    }

    public TokenResponse GenerateRefreshToken(int ExpireTime, ExpireType expireType)
    {

        DateTime _expires = DateTime.Now;

        switch (expireType)
        {
            case ExpireType.Seconds:
                _expires.AddSeconds(ExpireTime);
                break;
            case ExpireType.Minutes:
                _expires.AddMinutes(ExpireTime);
                break;
            case ExpireType.Hours:
                _expires.AddHours(ExpireTime);
                break;
            case ExpireType.Days:
                _expires.AddDays(ExpireTime);
                break;
            case ExpireType.Months:
                _expires.AddMonths(ExpireTime);
                break;
        }

        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        string refreshToken = Convert.ToBase64String(randomNumber);

        return new TokenResponse(refreshToken, _expires);

    }
}
