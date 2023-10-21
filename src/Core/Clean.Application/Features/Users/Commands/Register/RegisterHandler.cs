using Clean.Domain.Account;
using Clean.Domain.Repositories.Commands;
using Clean.Identity.Helpers;

namespace Clean.Application.Features.Users.Commands.Register;


public record RegisterRequest(string FirstName, string LastName, string Username, string Email, string Password, string? RoleId) : IRequest<RegisterResponse>;
public record RegisterResponse(bool Successed, string? message, List<string?> Errors);

public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
{
   
    private readonly IUserCommand _command;

    public RegisterHandler(IUserCommand command)
    {
        _command = command;
    }

    public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var validator = new RegisterValidator();
        var validation = validator.Validate(request);
        var errors = new List<string>();

        if (!validation.IsValid)
        {
            validation.Errors.ForEach(error => errors.Add(error.ErrorMessage));
            return new RegisterResponse(false, null, errors);
        }

        var user = new User(
            request.FirstName,
            request.LastName,
            request.Username,
            request.Email,
            request.Password.HashPassword(),
            request.RoleId!);

        await _command.CreateAsync(user, cancellationToken);
        return new RegisterResponse(true, "User is be register.", null);
    }

}
