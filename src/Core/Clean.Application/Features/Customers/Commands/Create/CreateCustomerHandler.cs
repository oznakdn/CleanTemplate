using Clean.Application.UnitOfWork.Commands;
using Clean.Domain.Baskets;
using Clean.Domain.Customers;
using Clean.Domain.Shared;

namespace Clean.Application.Features.Customers.Commands.Create;


public record CreateCustomerRequest(string FirstName, string LastName, string Email, string PhoneNumber, string Password, AddressRequest Address, CrediCardRequest CrediCard) : IRequest<TResult<CreateCustomerResponse>>;

public record AddressRequest(string Title, string District, int Number, string City);
public record CrediCardRequest(string Name, string CardNumber, string CardDate, string Cvv, decimal TotalLimit);

public record CreateCustomerResponse;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, TResult<CreateCustomerResponse>>
{
    private readonly ICommandUnitOfWork _command;
    private readonly CreateBasketEventHandler _createBasketEvent;

    public CreateCustomerHandler(ICommandUnitOfWork command, CreateBasketEventHandler createBasketEvent)
    {
        _command = command;
        _createBasketEvent = createBasketEvent;
    }

    public async Task<TResult<CreateCustomerResponse>> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var errors = new List<string>();
        TResult<Customer> customer = Customer.CreateCustomer(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber,
            request.Password);

        if (customer.IsFailed)
        {
            errors.AddRange(customer.Errors);
        }
        else
        {
            Result address = customer.Value.AddAddress(
             request.Address.Title,
             request.Address.District,
             request.Address.Number,
             request.Address.City);

            if (address.IsFailed)
                errors.AddRange(address.Errors);

            Result crediCard = customer.Value.AddCreditCard(
                 request.CrediCard.Name,
                 request.CrediCard.CardNumber,
                 request.CrediCard.CardDate,
                 request.CrediCard.Cvv,
                 request.CrediCard.TotalLimit);

            if (crediCard.IsFailed)
                errors.AddRange(crediCard.Errors);
        }



        if (errors.Count > 0)
            return TResult<CreateCustomerResponse>.Fail(errors);


        _command.Customer.Insert(customer.Value);
        Basket result = await _createBasketEvent.Publish(new CreateBasketEvent(customer.Value.Id.ToString()), cancellationToken);
        customer.Value.AddBasket(result.Id);

        await _command.Customer.ExecuteAsync(cancellationToken);

        return TResult<CreateCustomerResponse>.Ok("Customer was be register.");

    }
}
