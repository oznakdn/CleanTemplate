using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.OrderItems;
using Clean.Domain.Orders;
using Clean.Shared;


namespace Clean.Application.Features.Orders.Queries.GetCustomerOrders;



public record GetCustomerOrdersRequest(string customerId) : IRequest<IResult<GetCustomerOrdersResponse>>;
public record GetCustomerOrdersResponse(string Date, string Status, List<CustomerOrderItems> OrderItems);
public record CustomerOrderItems(string ProductId,int Quantity, decimal TotalAmount);

public class GetCustomerOrdersHandler : IRequestHandler<GetCustomerOrdersRequest, IResult<GetCustomerOrdersResponse>>
{
    private readonly IQueryUnitOfWork _query;

    public GetCustomerOrdersHandler(IQueryUnitOfWork query)
    {
        _query = query;
    }

    public async Task<IResult<GetCustomerOrdersResponse>> Handle(GetCustomerOrdersRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Order> customerOrders = await _query.Order.ReadAllAsync(
            noTracking: true,
            filter: x => x.CustomerId == Guid.Parse(request.customerId),
            cancellationToken: cancellationToken,
            includeProperties: x => x.OrderItems);

        List<OrderItem> orderItems = new();
        foreach (var order in customerOrders)
        {
            var item = await _query.OrderItem.QueryAsync(
            noTracking: true,
            filter: x => x.OrderId == order.Id,
            cancellationToken: cancellationToken);
            orderItems = item.ToList();
        }

        var items = orderItems.Select(x => new CustomerOrderItems(x.ProductId.ToString(),x.Quantity, x.TotalAmount)).ToList();


        var response = customerOrders.Select(x => new GetCustomerOrdersResponse(
            x.OrderDate.ToString(),
            x.Status.ToString(),
            items
            )).ToList();


        return Result<GetCustomerOrdersResponse>.Success(values: response);
    }
}
