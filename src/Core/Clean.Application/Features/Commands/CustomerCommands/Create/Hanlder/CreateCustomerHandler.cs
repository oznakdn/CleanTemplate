using Clean.Application.Features.Commands.CustomerCommands.Create.Dtos;
using Clean.Application.Features.Commands.CustomerCommands.Create.Validation;
using Clean.Domain.Entities.Customer;

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
        var response = new CreateCustomerResponse();
        var validator = new CreateCustomerValidator();
        var validation = validator.Validate(request);
        if (validation.IsValid)
        {

            Customer customer = _mongoUnitOfWork.Mapper.Map<Customer>(request);
            await _mongoUnitOfWork.Customer.InsertAsync(customer, cancellationToken);

            response.Success = true;
            response.Message = "Customer was added.";
            return response;
        }

        var erros = new List<string>();
        validation.Errors.ForEach(error => erros.Add(error.ErrorMessage));
        response.Success = false;
        response.Errors = erros;
        return response;
    }
}
