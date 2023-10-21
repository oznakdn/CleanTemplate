using Clean.Application.Results;
using Clean.Domain.Account;
using Clean.Domain.Repositories.Commands;
using Clean.Domain.Repositories.Queries;
using Clean.Identity.Helpers;
using Gleeman.JwtGenerator;
using Gleeman.JwtGenerator.Generator;
using MongoDB.Driver;

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
    private readonly IUserCommand _userCommand;
    private readonly IUserQuery _userQuery;
    private readonly IRoleQuery _roleQuery;
    private readonly ITokenGenerator _token;

    public LoginHandler(IUserCommand userCommand, IUserQuery userQuery,IRoleQuery roleQuery,  ITokenGenerator token)
    {
        _userCommand = userCommand;
        _userQuery = userQuery;
        _roleQuery = roleQuery;
        _token = token;

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

        var user = await _userQuery.ReadSingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
        var userRole = await _roleQuery.ReadSingleOrDefaultAsync(x => x.Id == user.RoleId, cancellationToken);

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

        var filter = Builders<User>.Filter
        .Eq(x => x.Id, user.Id);

        await _userCommand.EditAsync(filter,user, cancellationToken);

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
