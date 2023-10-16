using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Contracts.Abstracts;

public abstract class DomainEventHandler<TDomainEvent, TResponse>
where TDomainEvent : IDomaintEvent
where TResponse : class
{
    public event EventHandler<TDomainEvent> Event;
    public TResponse Response { get; set; }

    public virtual async Task<TResponse> Handle(TDomainEvent @event, CancellationToken cancellationToken)
    {
        Event.Invoke(this, @event);
        await Task.CompletedTask;
        return Response;
    }

    public async Task<TResponse> Publish(TDomainEvent @event, CancellationToken cancellationToken)
    {
        Response = await Handle(@event, cancellationToken);
        return Response;
    }
}
