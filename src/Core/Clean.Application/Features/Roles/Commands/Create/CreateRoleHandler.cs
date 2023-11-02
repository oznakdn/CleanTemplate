using Clean.Domain.Account;
using Clean.Domain.Repositories.Commands;
using Clean.Domain.Shared;

namespace Clean.Application.Features.Roles.Commands.Create;

public record CreateRoleRequest(string RoleTitle, string Description) : IRequest<TResult<CreateRoleResponse>>;
public record CreateRoleResponse;

public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, TResult<CreateRoleResponse>>
{
    private readonly IRoleCommand _command;

    public CreateRoleHandler(IRoleCommand command)
    {
        _command = command;
    }

    public async Task<TResult<CreateRoleResponse>> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var result = Role.CreateRole(request.RoleTitle,request.Description);
        if(result.IsFailed)
        {
            return TResult<CreateRoleResponse>.Fail(result.Errors.ToList());
        }

        await _command.InsertAsync(result.Value, cancellationToken);
        return  TResult<CreateRoleResponse>.Ok("Role was created.");
    }
}
