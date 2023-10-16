using Clean.Domain.Repositories;
using Clean.Domain.Users;
using Clean.Identity.Helpers;

namespace Clean.Application.Features.Users.Commands.Register;


public record RegisterRequest(string FirstName, string LastName, string Username, string Email, string Password, List<AddRoleRegister> Roles) : IRequest<RegisterResponse>;
public record AddRoleRegister(string Title, string Description);
public record RegisterResponse(bool Successed, string? message, List<string?> Errors);

public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
{
    private readonly IUserRepository _user;

    public RegisterHandler(IUserRepository user)
    {
        _user = user;
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
            request.Password.HashPassword());

        await _user.InsertAsync(user, cancellationToken);
        var roles = request.Roles.Select(x => new Role(x.Title, x.Description)).ToList();

        user.AddRoles(roles);
        await _user.UpdateAsync(user, cancellationToken);

        return new RegisterResponse(true, "User is be register.", null);
    }

}
