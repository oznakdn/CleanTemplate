using Clean.Domain.Users;
using Clean.Domain.Users.Repositories;
using Clean.Identity.Helpers;
using Clean.Shared;

namespace Clean.Application.Features.Users.Commands.Register;


public record RegisterRequest(string FirstName, string LastName, string Username, string Email, string Password, string? RoleId) : IRequest<IResult<RegisterResponse>>;
public record RegisterResponse;

public class RegisterHandler : IRequestHandler<RegisterRequest, IResult<RegisterResponse>>
{

    private readonly IUserCommand _command;

    public RegisterHandler(IUserCommand command)
    {
        _command = command;
    }

    public async Task<IResult<RegisterResponse>> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var validator = new RegisterValidator();
        var validation = validator.Validate(request);
        var errors = new List<string>();
        IResult<User> result;

        if (!validation.IsValid)
        {
            validation.Errors.ForEach(error => errors.Add(error.ErrorMessage));
            return Result<RegisterResponse>.Fail(errors: errors);
        }

        if (string.IsNullOrEmpty(request.RoleId))
        {
            result = User.CreateUser(request.FirstName, request.LastName, request.Username, request.Email, request.Password.HashPassword());

        }
        else
        {
            result = User.CreateUser(request.FirstName, request.LastName, request.Username, request.Email, request.Password.HashPassword(), request.RoleId);
        }

        if (!result.IsSuccess)
        {
            return Result<RegisterResponse>.Fail(errors: errors);
        }

        await _command.CreateAsync(result.Value, cancellationToken);
        return Result<RegisterResponse>.Success("User was be register.");
    }

}
