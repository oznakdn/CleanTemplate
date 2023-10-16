namespace Clean.Application.Features.Users.Commands.Register;

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().NotNull();
        RuleFor(x => x.LastName).NotEmpty().NotNull();
        RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
        RuleFor(x => x.Username).NotEmpty().NotNull();
        RuleFor(x => x.Password).NotEmpty().NotNull().Length(6, 10);
    }
}
