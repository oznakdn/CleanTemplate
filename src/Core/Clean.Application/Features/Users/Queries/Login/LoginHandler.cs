using Clean.Domain.Roles.Repositories;
using Clean.Domain.Shared;
using Clean.Domain.Users;
using Clean.Domain.Users.Repositories;
using Clean.Identity.Helpers;
using Gleeman.JwtGenerator;
using Gleeman.JwtGenerator.Generator;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Clean.Application.Features.Users.Queries.Login;


public record LoginRequest(string Email, string Password) : IRequest<TResult<LoginResponse>>;
public record LoginResponse(string AccessExpire, string RefreshToken, string RefreshExpire, string AccessToken);


public class LoginHandler : IRequestHandler<LoginRequest, TResult<LoginResponse>>
{
    private readonly IUserCommand _userCommand;
    private readonly IUserQuery _userQuery;
    private readonly IRoleQuery _roleQuery;
    private readonly ITokenGenerator _token;

    public LoginHandler(IUserCommand userCommand, IUserQuery userQuery, IRoleQuery roleQuery, ITokenGenerator token)
    {
        _userCommand = userCommand;
        _userQuery = userQuery;
        _roleQuery = roleQuery;
        _token = token;

    }

    public async Task<TResult<LoginResponse>> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var validator = new LoginValidator();
        var validation = validator.Validate(request);
        var errors = new List<string>();

        if (!validation.IsValid)
        {
            validation.Errors.ForEach(error => errors.Add(error.ErrorMessage));

            return TResult< LoginResponse >.Fail(errors);
        }

        var user = await _userQuery.ReadSingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
        var userRole = await _roleQuery.ReadSingleOrDefaultAsync(x => x.Id == user.RoleId, cancellationToken);

        if (user == null)
        {
            return TResult<LoginResponse>.Fail("User not found!");

        }

        bool passwordIsValid = request.Password.VerifyHashPassword(user.PasswordHash);

        if (!passwordIsValid)
        {
            return TResult<LoginResponse>.Fail("Password is wrong!");
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

        await _userCommand.EditAsync(filter, user, cancellationToken);


        var response = new LoginResponse(
            access.Token,
            access.ExpireDate.ToString(),
            refresh.Token,
            refresh.ExpireDate.ToString());

        return TResult<LoginResponse>.Ok(response);

    }
}
