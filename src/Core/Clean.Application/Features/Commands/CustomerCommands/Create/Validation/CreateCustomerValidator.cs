using Clean.Application.Features.Commands.CustomerCommands.Create.Dtos;

namespace Clean.Application.Features.Commands.CustomerCommands.Create.Validation;

public class CreateCustomerValidator: AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerValidator()
    {
        RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
        RuleFor(x=>x.FullName).NotEmpty().NotNull().Length(3,15);
    }
}
