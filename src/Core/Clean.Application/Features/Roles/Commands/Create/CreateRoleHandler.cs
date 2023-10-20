using Clean.Application.Results;
using Clean.Domain.Account;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Roles.Commands.Create;

public record CreateRoleRequest(string RoleTitle, string Description) : IRequest<IDataResult<CreateRoleResponse>>;
public record CreateRoleResponse;

public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, IDataResult<CreateRoleResponse>>
{
    private readonly IRoleRepository _role;

    public CreateRoleHandler(IRoleRepository role)
    {
        _role = role;
    }

    public async Task<IDataResult<CreateRoleResponse>> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        await _role.InsertAsync(new Role(request.RoleTitle, request.Description), cancellationToken);
        return new DataResult<CreateRoleResponse>("Role was created.",true);
    }
}
