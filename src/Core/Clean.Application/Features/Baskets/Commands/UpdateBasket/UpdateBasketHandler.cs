using Clean.Application.Results;
using Clean.Domain.Baskets;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Baskets.Commands.UpdateBasket;

public record UpdateBasketRequest(string BasketId, string BasketItemId, int Quantity) : IRequest<IDataResult<UpdateBasketResponse>>;
public record UpdateBasketResponse;

public class UpdateBasketHandler : IRequestHandler<UpdateBasketRequest, IDataResult<UpdateBasketResponse>>
{
    private readonly IBasketRepository _basket;
    private readonly UpdateBasketItemEventHandler _updateBasketItemEvent;

    public UpdateBasketHandler(IBasketRepository basket, UpdateBasketItemEventHandler updateBasketItemEvent)
    {
        _basket = basket;
        _updateBasketItemEvent = updateBasketItemEvent;
    }

    public async Task<IDataResult<UpdateBasketResponse>> Handle(UpdateBasketRequest request, CancellationToken cancellationToken)
    {
        var basket = await _basket.GetAsync(cancellationToken, x => x.Id == Guid.Parse(request.BasketId));

        if (basket is null)
            return new DataResult<UpdateBasketResponse>("Basket not found!", false);


        BasketItem basketItem = await _updateBasketItemEvent.Publish(new UpdateBasketItemEvent(
            Guid.Parse(request.BasketItemId),
            request.Quantity
            ), cancellationToken);

        basket.UpdateBasketItemQuantity(basketItem.ProductPrice, request.Quantity);

        _basket.Update(basket);
        await _basket.SaveAsync(cancellationToken);
        return new DataResult<UpdateBasketResponse>($"Item was updated to {request.Quantity}",true);
    }
}
