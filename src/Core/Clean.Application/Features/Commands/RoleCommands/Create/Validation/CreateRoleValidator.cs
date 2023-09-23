using Clean.Application.Features.Commands.RoleCommands.Create.Dtos;

namespace Clean.Application.Features.Commands.RoleCommands.Create.Validation;

public class CreateRoleValidator : AbstractValidator<CreateRoleRequest>
{
    public CreateRoleValidator()
    {
        RuleFor(x => x.RoleTitle).NotEmpty().NotNull().Length(3, 10);
        RuleFor(x => x.Description).NotEmpty().NotNull();
    }
}
