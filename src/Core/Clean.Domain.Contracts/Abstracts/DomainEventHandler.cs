using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Contracts.Abstracts;

public abstract class DomainEventHandler<TDomainEvent, TResponse>
where TDomainEvent : IDomaintEvent
where TResponse : class
{
    protected event EventHandler<TDomainEvent> Event;
    protected TResponse Response { get; set; }

    protected void EventInvoke(TDomainEvent @event) => Event.Invoke(this, @event);

    protected virtual async Task<TResponse> HandleAsync(TDomainEvent @event, CancellationToken cancellationToken)
    {
        return await Task.Run(() => Response);
    }
    protected virtual TResponse Handle(TDomainEvent @event)
    {
        return Response;
    }

    public async Task<TResponse> PublishAsync(TDomainEvent @event, CancellationToken cancellationToken) => await HandleAsync(@event, cancellationToken);
    public TResponse Publish(TDomainEvent @event) => Handle(@event);

}
