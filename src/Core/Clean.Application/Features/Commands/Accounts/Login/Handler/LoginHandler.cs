using Clean.Application.Features.Abstracts.Handler;
using Clean.Application.Features.Commands.Accounts.Login.Dtos;
using Clean.Domain.Identities;
using Clean.Identity.Identity.Interfaces;
using Clean.Identity.Jwt;
using Clean.Identity.Jwt.Handler;

namespace Clean.Application.Features.Commands.Accounts.Login.Handler;

public class LoginHandler : GenericHandler<LoginRequest, LoginResponse>
{
    private readonly IGenericUserIdentity<AppUser, Guid> _user;
    private readonly IJwtHandler _jwtHandler;

    public LoginHandler(IGenericUserIdentity<AppUser, Guid> user, IJwtHandler jwtHandler)
    {
        _user = user;
        _jwtHandler = jwtHandler;
    }

    public override async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var existUser = await _user.SigningUserAsync(request.Email, request.Password);
        if (existUser != null)
        {
            var refreshToken = _jwtHandler.GenerateRefreshToken(10, ExpireType.Days);
            var accessToken = _jwtHandler.GenerateToken<AppUser, Guid>(existUser, 5, ExpireType.Minutes);
            existUser.RefreshToken = refreshToken.Token;
            existUser.ExpiredDate = refreshToken.TokenExpiredDate;
            await _user.UpdateUserAsync(existUser);

            return new LoginResponse
            {
                Token = accessToken.Token,
                TokenExpiredDate = accessToken.TokenExpiredDate
            };
        }

        return null;
    }
}
