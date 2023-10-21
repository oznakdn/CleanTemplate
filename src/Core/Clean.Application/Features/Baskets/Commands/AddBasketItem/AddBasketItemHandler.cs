using Clean.Application.Results;
using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Baskets;
using Clean.Domain.Products;

namespace Clean.Application.Features.Baskets.Commands.AddBasketItem;

public record AddBasketItemRequest(string BasketId, string ProductId, int Quantity) : IRequest<IDataResult<AddBasketItemResponse>>;
public record AddBasketItemResponse;

public class AddBasketItemHandler : IRequestHandler<AddBasketItemRequest, IDataResult<AddBasketItemResponse>>
{
    private readonly ICommandUnitOfWork _command;
    private readonly IQueryUnitOfWork _query;
    private readonly AddBasketItemEventHandler _addBasketItemEvent;
    private readonly UpdateInventoryEventHandler _updateInventoryEvent;

    public AddBasketItemHandler(
        ICommandUnitOfWork command, 
        IQueryUnitOfWork query, 
        AddBasketItemEventHandler addBasketItemEvent, 
        UpdateInventoryEventHandler updateInventoryEvent)
    {
        _command = command;
        _query = query;
        _addBasketItemEvent = addBasketItemEvent;
        _updateInventoryEvent = updateInventoryEvent;
    }

    public async Task<IDataResult<AddBasketItemResponse>> Handle(AddBasketItemRequest request, CancellationToken cancellationToken)
    {
        new DataResult<AddBasketItemResponse>();

        var basket = await _query.Basket.ReadSingleOrDefaultAsync(true,x => x.Id == Guid.Parse(request.BasketId),cancellationToken);
        if (basket is null)
        {
           return new DataResult<AddBasketItemResponse>("Basket not found",false);
        }

        var product = await _query.Product.ReadSingleOrDefaultAsync(true, x => x.Id == Guid.Parse(request.ProductId), cancellationToken);
        if (product is null)
        {
           return new DataResult<AddBasketItemResponse>("Product not found",false);

        }

        // Updated inventory
        Inventory inventory = await _updateInventoryEvent.Publish(new UpdateInventoryEvent(product.Id,request.Quantity), cancellationToken);

        // Adding basketItem
        BasketItem basketItem = await _addBasketItemEvent.Publish(new AddBasketItemEvent(basket, product, request.Quantity), cancellationToken);
        basket.AddBasketItem(basketItem);

        // Saving in database
        _command.Basket.Edit(basket);
        await _command.Basket.ExecuteAsync(cancellationToken);

        return new DataResult<AddBasketItemResponse>("Item added in the basket", true);
    }
}
