﻿namespace Clean.Application.Features.Commands.Accounts.Login.Handler;

public class LoginHandler : AbstractHandler<LoginRequest, LoginResponse>
{
    private readonly IJwtHandler _jwtHandler;
    private readonly IEFUserRepository _user;

    public LoginHandler(IJwtHandler jwtHandler, IEFUserRepository user)
    {
        _jwtHandler = jwtHandler;
        _user = user;
    }

    public override async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var loginValidator = new LoginValidator();
        var errors = new List<string>();
        var validation = loginValidator.Validate(request);
        if (validation.IsValid)
        {
            var existUser = await _user.GetAsync(user => user.Email == request.Email && request.Password.VerifyHashPassword(user.PasswordHash));

            if (existUser != null)
            {
                var refreshToken = _jwtHandler.GenerateRefreshToken(10, ExpireType.Days);
                var accessToken = _jwtHandler.GenerateToken<AppUser, Guid>(existUser, 5, ExpireType.Minutes);
                existUser.RefreshToken = refreshToken.Token;
                existUser.ExpiredDate = refreshToken.TokenExpiredDate;
                _user.Update(existUser);
                await _user.SaveAsync();

                return new LoginResponse
                {
                    Token = accessToken.Token,
                    TokenExpiredDate = accessToken.TokenExpiredDate
                };
            }

            return new LoginResponse
            {
                Token = string.Empty,
                TokenExpiredDate = null,
                ErrorMessages = new List<string>() {"Email or Password is wrong!"}
            };
        }

        validation.Errors.ForEach(error => errors.Add(error.ErrorMessage));
        return new LoginResponse
        {
            Token = string.Empty,
            TokenExpiredDate = null,
            ErrorMessages = errors
        };

    }
}
