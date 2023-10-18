using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Contracts.Abstracts;

public abstract class DomainEventHandler<TDomainEvent, TResponse>
where TDomainEvent : IDomaintEvent
where TResponse : class
{
    protected event EventHandler<TDomainEvent> Event;
    protected TResponse Response { get; set; }

    protected abstract Task<TResponse> Handle(TDomainEvent @event, CancellationToken cancellationToken);
    protected void EventInvoke(TDomainEvent @event) => Event.Invoke(this, @event);

    public async Task<TResponse> Publish(TDomainEvent @event, CancellationToken cancellationToken) => await Handle(@event, cancellationToken);


}
