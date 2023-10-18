using Clean.Application.Results;
using Clean.Domain.Baskets;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Baskets.Commands.DeleteBasketItem;

public record DeleteBasketItemRequest(string BasketId, string BasketItemId) : IRequest<IDataResult<DeleteBasketItemResponse>>;
public record DeleteBasketItemResponse;


public class DeleteBasketItemHandler : IRequestHandler<DeleteBasketItemRequest, IDataResult<DeleteBasketItemResponse>>
{
    private readonly IBasketRepository _basket;
    private readonly DeleteBasketItemEventHandler _deleteBasketItemEvent;

    public DeleteBasketItemHandler(IBasketRepository basket, DeleteBasketItemEventHandler deleteBasketItemEvent)
    {
        _basket = basket;
        _deleteBasketItemEvent = deleteBasketItemEvent;
    }

    public async Task<IDataResult<DeleteBasketItemResponse>> Handle(DeleteBasketItemRequest request, CancellationToken cancellationToken)
    {
        var basket = await _basket.GetAsync(cancellationToken, x => x.Id == Guid.Parse(request.BasketId));

        if (basket is null)
            return new DataResult<DeleteBasketItemResponse>("Basket not found", false);

        BasketItem basketItem = await _deleteBasketItemEvent.Publish(new DeleteBasketItemEvent(
           Guid.Parse(request.BasketId),
           Guid.Parse(request.BasketItemId)
            ),cancellationToken);

        basket.RemoveBasketItem(basketItem);

        _basket.Update(basket);
        await _basket.SaveAsync(cancellationToken);

        return new DataResult<DeleteBasketItemResponse>("Item was removed",true);
    }
}
