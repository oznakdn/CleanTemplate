using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.OrderItems.Repositories;

public interface IOrderItemCommand : IEFCommandRepository<OrderItem,Guid>
{
}
