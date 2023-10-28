using Clean.Application.Results;
using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Baskets;
using Clean.Domain.Orders;

namespace Clean.Application.Features.Orders.Commands.Create;


public record CreateOrderRequest(string customerId) : IRequest<IDataResult<CreateOrderResponse>>;
public record CreateOrderResponse();

public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, IDataResult<CreateOrderResponse>>
{
    private readonly IQueryUnitOfWork _query;
    private readonly ICommandUnitOfWork _command;
    private readonly UpdateCustomerEventHandler _updateCustomerEventHandler;
    private readonly DeletedBasketItemsEventHandler _deletedBasketItemsEventHandler;
    private readonly CreateOrderItemEventHandler _createOrderItemEventHandler;

    public CreateOrderHandler(
        IQueryUnitOfWork query,
        ICommandUnitOfWork command,
        UpdateCustomerEventHandler updateCustomerEventHandler,
        DeletedBasketItemsEventHandler deletedBasketItemsEventHandler,
        CreateOrderItemEventHandler createOrderItemEventHandler)
    {
        _query = query;
        _command = command;
        _updateCustomerEventHandler = updateCustomerEventHandler;
        _deletedBasketItemsEventHandler = deletedBasketItemsEventHandler;
        _createOrderItemEventHandler = createOrderItemEventHandler;
    }

    public async Task<IDataResult<CreateOrderResponse>> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {

        var basket = await _query.Basket.ReadSingleOrDefaultAsync(
            noTracking: true,
            filter: x => x.CustomerId == Guid.Parse(request.customerId));

        var customer = await _query.Customer.ReadFirstOrDefaultAsync(
            noTracking: true,
            filter: x => x.Id == Guid.Parse(request.customerId));

        var basketItems = await _query.BasketItem.ReadAllAsync(
            noTracking: true,
            filter: x => x.BasketId == basket.Id);

        if (customer is null)
            return new DataResult<CreateOrderResponse>("Customer not found!", false);

        if (basket is null)
            return new DataResult<CreateOrderResponse>("Basket not found!", false);


        if (basket.TotalAmount > 0)
        {
            Order order = new(customer.Id);
            var result = customer.CreditCard.CardSpend(basket.TotalAmount);
            await _updateCustomerEventHandler.Publish(new UpdateCustomerEvent(customer), cancellationToken);
            if (result.IsFailed)
            {
                order.PaymentFailed();
            }
            else
            {
                order.PaymentRecived();
                // Burada basketItemlar orderItem lara setlenecek

                await _createOrderItemEventHandler.Publish(new CreateOrderItemEvent(basket.Id,order.Id), cancellationToken);
                await _deletedBasketItemsEventHandler.Publish(new DeletedBasketItemsEvent(basket.Id), cancellationToken);
                basket.ClearTotalAmount();
                _command.Basket.Update(basket);

            }

            await _command.Order.InsertAsync(order, cancellationToken);
            await _command.Order.ExecuteAsync(cancellationToken);

            return new DataResult<CreateOrderResponse>("Order has been created.", true);
        }

        return new DataResult<CreateOrderResponse>("Basket is empty!", false);
    }
}
