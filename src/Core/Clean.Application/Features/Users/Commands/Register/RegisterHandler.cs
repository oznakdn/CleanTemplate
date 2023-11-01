using Clean.Domain.Account;
using Clean.Domain.Repositories.Commands;
using Clean.Domain.Shared;

namespace Clean.Application.Features.Users.Commands.Register;


public record RegisterRequest(string FirstName, string LastName, string Username, string Email, string Password, string? RoleId) : IRequest<TResult<RegisterResponse>>;
public record RegisterResponse;

public class RegisterHandler : IRequestHandler<RegisterRequest, TResult<RegisterResponse>>
{
   
    private readonly IUserCommand _command;

    public RegisterHandler(IUserCommand command)
    {
        _command = command;
    }

    public async Task<TResult<RegisterResponse>> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var validator = new RegisterValidator();
        var validation = validator.Validate(request);
        var errors = new List<string>();
        
        if (!validation.IsValid)
        {
            validation.Errors.ForEach(error => errors.Add(error.ErrorMessage));
            return TResult<RegisterResponse>.Fail(errors);
        }

        var result = User.CreateUser(request.FirstName,request.LastName,request.Username,request.Email,request.Password);
        if(result.IsFailed)
        {
            return TResult<RegisterResponse>.Fail(errors);
        }
        
        await _command.CreateAsync(result.Value, cancellationToken);
        return TResult<RegisterResponse>.Ok("User was be register.");
    }

}
