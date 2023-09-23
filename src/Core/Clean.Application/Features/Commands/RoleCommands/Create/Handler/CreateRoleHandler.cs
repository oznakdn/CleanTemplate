using Clean.Application.Features.Commands.RoleCommands.Create.Dtos;
using Clean.Application.Features.Commands.RoleCommands.Create.Validation;
using Clean.Domain.Identities.SQL;

namespace Clean.Application.Features.Commands.RoleCommands.Create.Handler;

public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
{
    private readonly IEfUnitOfWork _efUnitOfWork;

    public CreateRoleHandler(IEfUnitOfWork efUnitOfWork)
    {
        _efUnitOfWork = efUnitOfWork;
    }

    public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateRoleValidator();
        var validation = validator.Validate(request);
        List<string> errors = new();
        if (validation.IsValid)
        {
            _efUnitOfWork.Role.Insert(_efUnitOfWork.Mapper.Map<AppRole>(request));
            await _efUnitOfWork.SaveAsync();
            return new CreateRoleResponse
            {
                Message = $"{request.RoleTitle} was added."
            };
        }

        validation.Errors.ForEach(e => errors.Add(e.ErrorMessage));
        return new CreateRoleResponse
        {
            Errors = errors,
            Message = string.Empty
        };
    }
}
