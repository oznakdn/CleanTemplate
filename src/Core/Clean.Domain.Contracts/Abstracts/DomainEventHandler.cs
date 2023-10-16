using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Contracts.Abstracts;

public abstract class DomainEventHandler<TDomainEvent>
where TDomainEvent : IDomaintEvent
{
    public event EventHandler<TDomainEvent> Event;

    public virtual async Task<TDomainEvent> Handle(TDomainEvent @event)
    {
        Event.Invoke(this, @event);
        return await Task.Run(() => @event);
    }

    public async Task<TDomainEvent> Publish(TDomainEvent @event)
    {
        return await Task.Run(() => Handle(@event));
    }
}
