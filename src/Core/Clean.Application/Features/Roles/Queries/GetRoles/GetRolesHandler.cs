using Clean.Domain.Roles;
using Clean.Domain.Roles.Repositories;
using Clean.Domain.Shared;
using Mapster;

namespace Clean.Application.Features.Roles.Queries.GetRoles;

public record GetRolesRequest:IRequest<TResult<GetRolesResponse>>;
public record GetRolesResponse(string Title, string Description);


public class GetRolesHandler : IRequestHandler<GetRolesRequest, TResult<GetRolesResponse>>
{
    private readonly IRoleQuery _query;

    public GetRolesHandler(IRoleQuery query)
    {
        _query = query;
    }

    public async Task<TResult<GetRolesResponse>> Handle(GetRolesRequest request, CancellationToken cancellationToken)
    {
        var roles = await _query.ReadAllAsync();

        var config = new TypeAdapterConfig();

        config.NewConfig<Role,GetRolesResponse>()
        .Map(dest=> dest.Title,src=> src.RoleTitle);

        var result = roles.Adapt<IEnumerable<GetRolesResponse>>(config);
        return TResult<GetRolesResponse>.Ok(result);
    }
}