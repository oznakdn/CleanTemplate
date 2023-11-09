using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Inventories.Repositories;

public interface IInventoryCommand : IEFCommandRepository<Inventory,Guid>
{
}
