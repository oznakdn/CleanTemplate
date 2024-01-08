using Clean.Domain.Roles;
using Clean.Domain.Roles.Repositories;
using Clean.Shared;
using Mapster;

namespace Clean.Application.Features.Roles.Queries.GetRoles;

public record GetRolesRequest : IRequest<IResult<GetRolesResponse>>;
public record GetRolesResponse(string Id, string Title, string Description);


public class GetRolesHandler : IRequestHandler<GetRolesRequest, IResult<GetRolesResponse>>
{
    private readonly IRoleQuery _query;

    public GetRolesHandler(IRoleQuery query)
    {
        _query = query;
    }

    public async Task<IResult<GetRolesResponse>> Handle(GetRolesRequest request, CancellationToken cancellationToken)
    {
        var roles = await _query.ReadAllAsync();

        var config = new TypeAdapterConfig();

        config.NewConfig<Role, GetRolesResponse>()
        .Map(dest => dest.Title, src => src.RoleTitle)
        .Map(dest => dest.Id, src => src.Id.ToString());

        var result = roles.Adapt<IEnumerable<GetRolesResponse>>(config);
        return Result<GetRolesResponse>.Success(values: result);
    }
}