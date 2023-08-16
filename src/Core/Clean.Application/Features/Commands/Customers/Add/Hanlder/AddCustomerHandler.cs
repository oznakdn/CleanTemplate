namespace Clean.Application.Features.Commands.Customers.Add.Hanlder;

public class AddCustomerHandler:AbstractHandler<AddCustomerRequest, AddCustomerResponse>
{
    private readonly IMongoCustomerRepository _mongoCustomer;

    public AddCustomerHandler(IMongoCustomerRepository mongoCustomer)
    {
        _mongoCustomer = mongoCustomer;
    }

    public async override Task<AddCustomerResponse> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
    {
        var errorMessages = new List<string>();
        var validator = new AddCustomerValidator();
        var validation = validator.Validate(request);
        if(validation.IsValid)
        {
            Customer customer = _mongoCustomer.Mapper.Map<Customer>(request);
            await _mongoCustomer.InsertAsync(customer, cancellationToken);
            return new AddCustomerResponse
            {
                Messages = new List<string> { "Customer was added." }
            };
        }

        validation.Errors.ForEach(error => errorMessages.Add(error.ErrorMessage));
        return new AddCustomerResponse
        {
            Messages = errorMessages,
            Success = false
        };

    }
}
