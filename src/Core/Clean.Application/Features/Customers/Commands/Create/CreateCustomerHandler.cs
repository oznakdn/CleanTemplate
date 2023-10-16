using Clean.Application.Results;
using Clean.Domain.Baskets;
using Clean.Domain.Customers;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Customers.Commands.Create;


public record CreateCustomerRequest(string FirstName, string LastName, string Email, string PhoneNumber, string Password, AddressRequest Address) : IRequest<CreateCustomerResponse>;

public record AddressRequest(string Title, string District, int Number, string City);
public class CreateCustomerResponse : Response { }

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    private readonly ICustomerRepository _customer;
    private readonly CreateBasketEventHandler _createBasketEvent;

    public CreateCustomerHandler(ICustomerRepository customer, CreateBasketEventHandler createBasketEvent)
    {
        _customer = customer;
        _createBasketEvent = createBasketEvent;
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        Customer customer = new(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber,
            request.Password
            );

        customer.AddAddress(
            request.Address.Title,
            request.Address.District,
            request.Address.Number,
            request.Address.City);

        _customer.Insert(customer);

        Basket result = await _createBasketEvent.Publish(new CreateBasketEvent(customer.Id.ToString()), cancellationToken);
        customer.AddBasket(result.Id);

        await _customer.SaveAsync(cancellationToken);

        return new CreateCustomerResponse
        {
            Successed = true,
            Message = "Customer was be register."
        };
    }
}
