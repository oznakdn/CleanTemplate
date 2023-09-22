namespace Clean.Application.Features.Commands.Customers.Add.Hanlder;

public class AddCustomerHandler : IRequestHandler<AddCustomerRequest, AddCustomerResponse>
{
    private readonly IMongoUnitOfWork _mongoUnitOfWork;

    public AddCustomerHandler(IMongoUnitOfWork mongoUnitOfWork)
    {
        _mongoUnitOfWork = mongoUnitOfWork;
    }

    public async Task<AddCustomerResponse> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
    {
        var errorMessages = new List<string>();
        var validator = new AddCustomerValidator();
        var validation = validator.Validate(request);
        if (validation.IsValid)
        {

            Customer customer = _mongoUnitOfWork.Mapper.Map<Customer>(request);
            await _mongoUnitOfWork.Customer.InsertAsync(customer, cancellationToken);
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
