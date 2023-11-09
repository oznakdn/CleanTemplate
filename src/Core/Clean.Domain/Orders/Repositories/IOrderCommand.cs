using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Orders.Repositories;

public interface IOrderCommand : IEFCommandRepository<Order,Guid>
{
}
