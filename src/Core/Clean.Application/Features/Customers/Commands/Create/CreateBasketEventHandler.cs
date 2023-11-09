using Clean.Application.UnitOfWork.Commands;
using Clean.Domain.Baskets;
using Clean.Domain.Baskets.Events;
using Clean.Domain.Contracts.Abstracts;

namespace Clean.Application.Features.Customers.Commands.Create;



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
