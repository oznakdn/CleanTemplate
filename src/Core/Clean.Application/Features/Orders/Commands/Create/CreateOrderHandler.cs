using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.BasketItems.Events;
using Clean.Domain.Customers.Events;
using Clean.Domain.OrderItems.Events;
using Clean.Domain.Orders;
using Clean.Shared;


namespace Clean.Application.Features.Orders.Commands.Create;


public record CreateOrderRequest(string customerId) : IRequest<IResult<CreateOrderResponse>>;
public record CreateOrderResponse();

public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, IResult<CreateOrderResponse>>
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

    public async Task<IResult<CreateOrderResponse>> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {

        var basket = await _query.Basket.ReadSingleOrDefaultAsync(
            noTracking: true,
            filter: x => x.CustomerId == Guid.Parse(request.customerId));

        var customer = await _query.Customer.ReadFirstOrDefaultAsync(
            noTracking: true,
            filter: x => x.Id == Guid.Parse(request.customerId));

        if (basket is null)
            return  Result<CreateOrderResponse>.Fail("Basket not found!");

        if (customer is null)
            return Result<CreateOrderResponse>.Fail("Customer not found!");

        if(customer.CreditCard is null)
        {
            // Will create a new credit card for this customer if has not
        }
      

        if (basket.TotalAmount > 0)
        {
            Order order = new(customer.Id);
            var result = customer.CreditCard.CardSpend(basket.TotalAmount);
            await _updateCustomerEventHandler.PublishAsync(new UpdateCustomerEvent(customer), cancellationToken);
            if (!result.IsSuccess)
            {
                order.PaymentFailed();
            }
            else
            {
                order.PaymentRecived();
                await _createOrderItemEventHandler.PublishAsync(new CreateOrderItemEvent(basket.Id,order.Id), cancellationToken);
                await _deletedBasketItemsEventHandler.PublishAsync(new DeletedBasketItemsEvent(basket.Id), cancellationToken);
                basket.ClearTotalAmount();
                _command.Basket.Update(basket);

            }

            await _command.Order.InsertAsync(order, cancellationToken);
            await _command.Order.ExecuteAsync(cancellationToken);

            return  Result<CreateOrderResponse>.Success("Order has been created.");
        }

        return  Result<CreateOrderResponse>.Fail("Basket is empty!");
    }
}
