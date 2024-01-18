using Clean.Domain.Users;
using Clean.Domain.Users.Repositories;
using Clean.Identity.Helpers;
using Clean.Shared;

namespace Clean.Application.Features.Users.Commands.Register;


public record RegisterRequest(string FirstName, string LastName, string Username, string Email, string Password, string? RoleId) : IRequest<IResult>;

public class RegisterHandler : IRequestHandler<RegisterRequest, IResult>
{

    private readonly IUserCommand _command;
    private readonly IUserQuery _query;
    public RegisterHandler(IUserCommand command, IUserQuery query)
    {
        _command = command;
        _query = query;
    }

    public async Task<IResult> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {

        var validator = new RegisterValidator();
        var validation = validator.Validate(request);
        var errors = new List<string>();

        if (!validation.IsValid)
        {
            validation.Errors.ForEach(error => errors.Add(error.ErrorMessage));
            return Result.Fail(errors: errors);
        }


        User? existUser = await _query.ReadFirstOrDefaultAsync(x => x.Email == request.Email);

        if (existUser is not null)
            return Result.Fail("You cannot that entered email address!");
        

        IResult<User> result;

        if (string.IsNullOrEmpty(request.RoleId))
            result = User.CreateUser(request.FirstName, request.LastName, request.Username, request.Email, request.Password.HashPassword());

        else
            result = User.CreateUser(request.FirstName, request.LastName, request.Username, request.Email, request.Password.HashPassword(), request.RoleId);


        if (!result.IsSuccess)
            return Result.Fail(errors: errors);
        

        await _command.CreateAsync(result.Value, cancellationToken);
        return Result.Success("Registration is successfully.");
    }
}
