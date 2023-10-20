using Clean.Application.Results;
using Clean.Domain.Repositories;
using Clean.Identity.Helpers;
using Gleeman.JwtGenerator;
using Gleeman.JwtGenerator.Generator;

namespace Clean.Application.Features.Users.Queries.Login;


public record LoginRequest(string Email, string Password) : IRequest<LoginResponse>;
public class LoginResponse : Response
{
    public string AccessExpire { get; set; }
    public string RefreshToken { get; set; }
    public string RefreshExpire { get; set; }
    public string AccessToken { get; set; }
}


public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IUserRepository _user;
    private readonly IRoleRepository _role;
    private readonly ITokenGenerator _token;

    public LoginHandler(IUserRepository user, ITokenGenerator token, IRoleRepository role)
    {
        _user = user;
        _token = token;
        _role = role;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var validator = new LoginValidator();
        var validation = validator.Validate(request);
        var errors = new List<string>();

        if (!validation.IsValid)
        {
            validation.Errors.ForEach(error => errors.Add(error.ErrorMessage));
            return new LoginResponse
            {
                Errors = errors,
                Successed = false
            };
        }

        var user = await _user.GetAsync(x => x.Email == request.Email, cancellationToken);
        var userRole = await _role.GetAsync(x => x.Id == user.RoleId, cancellationToken);

        if (user == null)
        {
            return new LoginResponse
            {
                Message = "User not found!",
                Successed = false
            };
        }



        bool passwordIsValid = request.Password.VerifyHashPassword(user.PasswordHash);

        if (!passwordIsValid)
        {
            return new LoginResponse
            {
                Message = "User not found!",
                Successed = false
            };
        }

        var userParameter = new UserParameter
        {
            Id = user.Id,
            Email = user.Email,
            Username = user.Username
        };

        TokenResult access;
        if (userRole != null)
        {
            RoleParameter roleParameter = new();
            roleParameter.Role = userRole.RoleTitle;
            access = _token.GenerateAccessToken(userParameter, roleParameter, ExpireType.Day, 5);
        }
        else
        {
            access = _token.GenerateAccessToken(userParameter, ExpireType.Day, 5);
        }

        TokenResult refresh = _token.GenerateRefreshToken(ExpireType.Day, 6);

        user.SetRefreshToken(refresh.Token, refresh.ExpireDate);

        await _user.UpdateAsync(user, cancellationToken);

        return new LoginResponse
        {
            AccessToken = access.Token,
            AccessExpire = access.ExpireDate.ToString(),
            RefreshToken = refresh.Token,
            RefreshExpire = refresh.ExpireDate.ToString(),
            Successed = true
        };


    }
}
