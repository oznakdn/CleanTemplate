using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Inventories.Repositories;

public interface IInventoryQuery : IEFQueryRepository<Inventory,Guid>
{
}
