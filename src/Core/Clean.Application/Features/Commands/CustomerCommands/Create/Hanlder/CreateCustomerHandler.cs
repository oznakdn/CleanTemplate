using Clean.Application.Features.Commands.CustomerCommands.Create.Dtos;
using Clean.Application.Features.Commands.CustomerCommands.Create.Validation;

namespace Clean.Application.Features.Commands.CustomerCommands.Create.Hanlder;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    private readonly IMongoUnitOfWork _mongoUnitOfWork;

    public CreateCustomerHandler(IMongoUnitOfWork mongoUnitOfWork)
    {
        _mongoUnitOfWork = mongoUnitOfWork;
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var errorMessages = new List<string>();
        var validator = new CreateCustomerValidator();
        var validation = validator.Validate(request);
        if (validation.IsValid)
        {

            Customer customer = _mongoUnitOfWork.Mapper.Map<Customer>(request);
            await _mongoUnitOfWork.Customer.InsertAsync(customer, cancellationToken);
            return new CreateCustomerResponse
            {
                Messages = new List<string> { "Customer was added." }
            };
        }

        validation.Errors.ForEach(error => errorMessages.Add(error.ErrorMessage));
        return new CreateCustomerResponse
        {
            Messages = errorMessages,
            Success = false
        };

    }
}
