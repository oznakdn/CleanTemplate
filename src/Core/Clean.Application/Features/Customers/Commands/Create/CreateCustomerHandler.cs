﻿using Clean.Application.Results;
using Clean.Application.UnitOfWork.Commands;
using Clean.Domain.Baskets;
using Clean.Domain.Customers;

namespace Clean.Application.Features.Customers.Commands.Create;


public record CreateCustomerRequest(string FirstName, string LastName, string Email, string PhoneNumber, string Password, AddressRequest Address, CrediCardRequest CrediCard) : IRequest<CreateCustomerResponse>;

public record AddressRequest(string Title, string District, int Number, string City);
public record CrediCardRequest(string Name, string CardNumber, string CardDate, string Cvv, decimal TotalLimit);

public class CreateCustomerResponse : Response { }

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    private readonly ICommandUnitOfWork _command;
    private readonly CreateBasketEventHandler _createBasketEvent;

    public CreateCustomerHandler(ICommandUnitOfWork command, CreateBasketEventHandler createBasketEvent)
    {
        _command = command;
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

        customer.AddCreditCard(
            request.CrediCard.Name,
            request.CrediCard.CardNumber,
            request.CrediCard.CardDate,
            request.CrediCard.Cvv,
            request.CrediCard.TotalLimit
            );

        _command.Customer.Insert(customer);

        Basket result = await _createBasketEvent.Publish(new CreateBasketEvent(customer.Id.ToString()), cancellationToken);
        customer.AddBasket(result.Id);

        await _command.Customer.ExecuteAsync(cancellationToken);

        return new CreateCustomerResponse
        {
            Successed = true,
            Message = "Customer was be register."
        };
    }
}
