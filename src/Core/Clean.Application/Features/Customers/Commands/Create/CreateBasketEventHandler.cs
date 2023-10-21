using Clean.Application.UnitOfWork.Commands;
using Clean.Domain.Baskets;
using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;

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
    private readonly ICommandUnitOfWork _command;

    public CreateBasketEventHandler(ICommandUnitOfWork command)
    {
        _command = command;
    }

    protected async override Task<Basket> Handle(CreateBasketEvent @event, CancellationToken cancellationToken)
    {

        Event += (s, e) => _command.Basket.Insert(@event.Basket = new Basket(Guid.Parse(e.CustomerId)));
        EventInvoke(@event);
        await Task.FromResult(@event.Basket);
        return @event.Basket;
    }

}
