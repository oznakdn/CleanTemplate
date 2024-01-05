using Clean.Domain.Roles.Repositories;
using Clean.Domain.Shared;
using Clean.Domain.Users;
using Clean.Domain.Users.Repositories;
using MongoDB.Driver;

namespace Clean.Application.Features.Roles.Commands.AssignRole;


public record AssignRoleRequest(string UserId, string RoleId) : IRequest<TResult<AssignRoleResponse>>;
public record AssignRoleResponse;

public class AssignRoleHandler : IRequestHandler<AssignRoleRequest, TResult<AssignRoleResponse>>
{
    private readonly IRoleQuery _roleQuery;
    private readonly IUserQuery _userQuery;
    private readonly IUserCommand _userCommand;

    public AssignRoleHandler(IRoleQuery roleQuery, IUserQuery userQuery, IUserCommand userCommand)
    {
        _roleQuery = roleQuery;
        _userQuery = userQuery;
        _userCommand = userCommand;
    }

    public async Task<TResult<AssignRoleResponse>> Handle(AssignRoleRequest request, CancellationToken cancellationToken)
    {
        var role = await _roleQuery.ReadSingleOrDefaultAsync(x => x.Id == request.RoleId, cancellationToken);
        var user = await _userQuery.ReadSingleOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

        if (role is null)
        {
            return TResult<AssignRoleResponse>.Fail("Role not found!");
        }

        if (user is null)
        {
            return TResult<AssignRoleResponse>.Fail("User not found!");
        }

        if (user.RoleId == role.Id)
        {
            return TResult<AssignRoleResponse>.Fail("User has already this role");
        }

        user.AssignRole(role.Id);
        var filter = new FilterDefinitionBuilder<User>().Eq(x => x.Id, user.Id);

        await _userCommand.EditAsync(filter, user, cancellationToken);

        return TResult<AssignRoleResponse>.Ok("The role has been assigned to the user.");
    }
}
