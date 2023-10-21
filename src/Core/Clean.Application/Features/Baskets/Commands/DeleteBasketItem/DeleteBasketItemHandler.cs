using Clean.Application.Results;
using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Baskets;

namespace Clean.Application.Features.Baskets.Commands.DeleteBasketItem;

public record DeleteBasketItemRequest(string BasketId, string BasketItemId) : IRequest<IDataResult<DeleteBasketItemResponse>>;
public record DeleteBasketItemResponse;


public class DeleteBasketItemHandler : IRequestHandler<DeleteBasketItemRequest, IDataResult<DeleteBasketItemResponse>>
{
    private readonly IQueryUnitOfWork _query;
    private readonly ICommandUnitOfWork _command;
    private readonly DeleteBasketItemEventHandler _deleteBasketItemEvent;

    public DeleteBasketItemHandler(IQueryUnitOfWork query, ICommandUnitOfWork command, DeleteBasketItemEventHandler deleteBasketItemEvent)
    {
        _query = query;
        _command = command;
        _deleteBasketItemEvent = deleteBasketItemEvent;
    }

    public async Task<IDataResult<DeleteBasketItemResponse>> Handle(DeleteBasketItemRequest request, CancellationToken cancellationToken)
    {
        var basket = await _query.Basket.ReadSingleOrDefaultAsync(true, x => x.Id == Guid.Parse(request.BasketId), cancellationToken);

        if (basket is null)
            return new DataResult<DeleteBasketItemResponse>("Basket not found", false);

        BasketItem basketItem = await _deleteBasketItemEvent.Publish(new DeleteBasketItemEvent(
           Guid.Parse(request.BasketId),
           Guid.Parse(request.BasketItemId)
            ), cancellationToken);

        basket.RemoveBasketItem(basketItem);

        _command.Basket.Edit(basket);
        await _command.Basket.ExecuteAsync(cancellationToken);

        return new DataResult<DeleteBasketItemResponse>("Item was removed", true);
    }
}
