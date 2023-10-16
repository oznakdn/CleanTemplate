using Clean.Domain.Baskets;
using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Customers.Commands.Create;


public class CreateBasketEvent : IDomaintEvent
{
    public CreateBasketEvent(string customerId)
    {
        CustomerId = customerId;
    }

    public string CustomerId { get; set; }
}
public class CreateBasketEventHandler : DomainEventHandler<CreateBasketEvent, Basket>
{
    private readonly IBasketRepository _basket;

    public CreateBasketEventHandler(IBasketRepository basket)
    {
        _basket = basket;
    }

    public override async Task<Basket> Handle(CreateBasketEvent @event, CancellationToken cancellationToken)
    {
        Basket basket = null;
        this.Event += (s, e) => _basket.Insert(basket = new Basket(Guid.Parse(e.CustomerId)));
        await base.Handle(@event, cancellationToken);
        return basket;
    }


}
