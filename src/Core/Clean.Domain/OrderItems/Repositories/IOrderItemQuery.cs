using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.OrderItems.Repositories;

public interface IOrderItemQuery : IEFQueryRepository<OrderItem,Guid>
{
}
