using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.BasketItems.Repositories;

public interface IBasketItemCommand : IEFCommandRepository<BasketItem,Guid>
{
}
