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
    public Basket Basket { get; set; }
}
public class CreateBasketEventHandler : DomainEventHandler<CreateBasketEvent, Basket>
{
    private readonly IBasketRepository _basket;

    public CreateBasketEventHandler(IBasketRepository basket)
    {
        _basket = basket;
    }

    protected async override Task<Basket> Handle(CreateBasketEvent @event, CancellationToken cancellationToken)
    {
       
        Event += (s, e) => _basket.Insert(@event.Basket = new Basket(Guid.Parse(e.CustomerId)));
        EventInvoke(@event);
        await Task.FromResult(@event.Basket);
        return @event.Basket;
    }



}
