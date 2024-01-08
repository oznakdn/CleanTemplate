using Clean.Domain.Roles;
using Clean.Domain.Roles.Repositories;
using Clean.Shared;

namespace Clean.Application.Features.Roles.Commands.Create;

public record CreateRoleRequest(string RoleTitle, string Description) : IRequest<IResult<CreateRoleResponse>>;
public record CreateRoleResponse;

public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, IResult<CreateRoleResponse>>
{
    private readonly IRoleCommand _command;

    public CreateRoleHandler(IRoleCommand command)
    {
        _command = command;
    }

    public async Task<IResult<CreateRoleResponse>> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var result = Role.CreateRole(request.RoleTitle,request.Description);
        if(!result.IsSuccess)
        {
            return Result<CreateRoleResponse>.Fail(errors: result.Errors);
        }

        await _command.InsertAsync(result.Value, cancellationToken);
        return  Result<CreateRoleResponse>.Success("Role was created.");
    }
}
