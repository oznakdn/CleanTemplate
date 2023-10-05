using MediatR;

namespace Clean.Domain.Contracts.Events;

public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent>
where TDomainEvent : IDomaintEvent
{
}
