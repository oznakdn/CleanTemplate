using Clean.Application.Features.Commands.UserCommands.Register.Dtos;

namespace Clean.Application.Features.Commands.UserCommands.Register.Validation;

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
        RuleFor(x => x.PasswordHash).NotEmpty().NotNull().Length(6, 10);
    }
}
