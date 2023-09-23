using Clean.Application.Features.Queries.UserQueries.Login.Dtos;
using Clean.Application.Features.Queries.UserQueries.Login.Validation;
using Gleeman.JwtGenerator;
using Gleeman.JwtGenerator.Generator;

namespace Clean.Application.Features.Queries.UserQueries.Login.Handler;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IEfUnitOfWork _efUnitOfWork;
    private readonly ITokenGenerator _tokenGenerator;
    public LoginHandler(IEfUnitOfWork efUnitOfWork, ITokenGenerator tokenGenerator)
    {
        _efUnitOfWork = efUnitOfWork;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var loginValidator = new LoginValidator();
        var errors = new List<string>();
        var validation = loginValidator.Validate(request);
        if (validation.IsValid)
        {
            var user = _efUnitOfWork.User;
            var existUser = await user.GetAsync(user => user.Email == request.Email && request.Password.VerifyHashPassword(user.PasswordHash), user => user.Role);

            if (existUser != null)
            {
                TokenParameter tokenParameter = new()
                {
                    Username = existUser.Username,
                    Email = existUser.Email,
                    Role = existUser.Role != null ? existUser.Role.RoleTitle : null
                };
                var accessToken = _tokenGenerator.GenerateAccessToken(tokenParameter, ExpireType.Hour, 1);
                var refreshToken = _tokenGenerator.GenerateRefreshToken(ExpireType.Hour, 2);
                existUser.RefreshToken = refreshToken.Token;
                existUser.ExpiredDate = refreshToken.ExpireDate;
                user.Update(existUser);
                await _efUnitOfWork.SaveAsync();

                return new LoginResponse
                {
                    Token = accessToken.Token,
                    TokenExpiredDate = accessToken.ExpireDate
                };
            }

            return new LoginResponse
            {
                Token = string.Empty,
                TokenExpiredDate = null,
                ErrorMessages = new List<string>() { "Email or Password is wrong!" }
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
