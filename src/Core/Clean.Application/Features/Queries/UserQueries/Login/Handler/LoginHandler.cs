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
        var response = new LoginResponse();
        var loginValidator = new LoginValidator();
        var validation = loginValidator.Validate(request);

        if (validation.IsValid)
        {

            var existUser = await _efUnitOfWork.User.GetAsync(cancellationToken,user => user.Email == request.Email, user => user.Role);
            if (existUser == null)
            {
                response.Success = false;
                response.Message = "Email is wrong!";
                return response;
            }

            bool passwordIsValid = request.Password.VerifyHashPassword(existUser.PasswordHash);

            if (passwordIsValid && existUser != null)
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
                _efUnitOfWork.User.Update(existUser);
                await _efUnitOfWork.SaveAsync();

                response.Success = true;
                response.Token = accessToken.Token;
                response.TokenExpiredDate = accessToken.ExpireDate;
                return response;
            }

            response.Success = false;
            response.Message = "Email or Password is wrong!";
            return response;
        }

        var errors = new List<string>();
        validation.Errors.ForEach(error => errors.Add(error.ErrorMessage));
        response.Success = false;
        response.ErrorMessages = errors;
        return response;
    }
}
