using Clean.Application.Results;
using Clean.Domain.Account;
using Clean.Domain.Repositories.Commands;

namespace Clean.Application.Features.Roles.Commands.Create;

public record CreateRoleRequest(string RoleTitle, string Description) : IRequest<IDataResult<CreateRoleResponse>>;
public record CreateRoleResponse;

public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, IDataResult<CreateRoleResponse>>
{
    private readonly IRoleCommand _command;

    public CreateRoleHandler(IRoleCommand command)
    {
        _command = command;
    }

    public async Task<IDataResult<CreateRoleResponse>> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        await _command.InsertAsync(new Role(request.RoleTitle, request.Description), cancellationToken);
        return new DataResult<CreateRoleResponse>("Role was created.",true);
    }
}
