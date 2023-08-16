namespace Clean.Application.Features.Commands.Customers.Add.Validation;

public class AddCustomerValidator: AbstractValidator<AddCustomerRequest>
{
    public AddCustomerValidator()
    {
        RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
        RuleFor(x=>x.FullName).NotEmpty().NotNull().Length(3,15);
    }
}
