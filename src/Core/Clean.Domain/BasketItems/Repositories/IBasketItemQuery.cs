using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.BasketItems.Repositories;

public interface IBasketItemQuery : IEFQueryRepository<BasketItem,Guid>
{
}
