using Clean.Application.UnitOfWork.Commands;
using Clean.Domain.Baskets;
using Clean.Domain.Baskets.Events;
using Clean.Domain.Customers;
using Clean.Identity.Helpers;
using Clean.Shared;

namespace Clean.Application.Features.Customers.Commands.Create;


public record CreateCustomerRequest(string FirstName, string LastName, string Email, string PhoneNumber, string Password, AddressRequest Address) : IRequest<IResult<CreateCustomerResponse>>;

public record AddressRequest(string Title, string District, int Number, string City);
public record CrediCardRequest(string Name, string CardNumber, string CardDate, string Cvv, decimal TotalLimit);

public record CreateCustomerResponse;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, IResult<CreateCustomerResponse>>
{
    private readonly ICommandUnitOfWork _command;
    private readonly CreateBasketEventHandler _createBasketEvent;

    public CreateCustomerHandler(ICommandUnitOfWork command, CreateBasketEventHandler createBasketEvent)
    {
        _command = command;
        _createBasketEvent = createBasketEvent;
    }

    public async Task<IResult<CreateCustomerResponse>> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var errors = new List<string>();
        IResult<Customer> customer = Customer.CreateCustomer(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber,
            request.Password.HashPassword());

        if (!customer.IsSuccess)
        {
            errors.AddRange(customer.Errors);
        }
        else
        {
            IResult address = customer.Value.AddAddress(
             request.Address.Title,
             request.Address.District,
             request.Address.Number,
             request.Address.City);

            if (!address.IsSuccess)
                errors.AddRange(address.Errors);

            //Result crediCard = customer.Value.AddCreditCard(
            //     request.CrediCard.Name,
            //     request.CrediCard.CardNumber,
            //     request.CrediCard.CardDate,
            //     request.CrediCard.Cvv,
            //     request.CrediCard.TotalLimit);

            //if (crediCard.IsFailed)
            //    errors.AddRange(crediCard.Errors);
        }



        if (errors.Count > 0)
            return Result<CreateCustomerResponse>.Fail(errors:errors);


        _command.Customer.Insert(customer.Value);
        Basket result = await _createBasketEvent.PublishAsync(new CreateBasketEvent(customer.Value.Id.ToString()), cancellationToken);
        customer.Value.AddBasket(result.Id);

        await _command.Customer.ExecuteAsync(cancellationToken);

        return Result<CreateCustomerResponse>.Success("Customer was be register.");

    }
}
