using Clean.Application.Results;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Orders;
using Mapster;

namespace Clean.Application.Features.Orders.Queries.GetCustomerOrders;



public record GetCustomerOrdersRequest(string customerId) : IRequest<IDataResult<GetCustomerOrdersResponse>>;
public record GetCustomerOrdersResponse(string Date, string Status, List<CustomerOrderItems> OrderItems);
public record CustomerOrderItems(int Quantity, decimal TotalAmount);

public class GetCustomerOrdersHandler : IRequestHandler<GetCustomerOrdersRequest, IDataResult<GetCustomerOrdersResponse>>
{
    private readonly IQueryUnitOfWork _query;

    public GetCustomerOrdersHandler(IQueryUnitOfWork query)
    {
        _query = query;
    }

    public async Task<IDataResult<GetCustomerOrdersResponse>> Handle(GetCustomerOrdersRequest request, CancellationToken cancellationToken)
    {
        var customerOrders = await _query.Order.ReadAllAsync(
            noTracking: true,
            filter: x => x.CustomerId == Guid.Parse(request.customerId),
            cancellationToken: cancellationToken,
            includeProperties: x => x.OrderItems);

        TypeAdapterConfig config = new TypeAdapterConfig();

        config.NewConfig<Order, GetCustomerOrdersResponse>()
            .Map(dest => dest.Date, src => src.OrderDate.ToString())
            .Map(dest => dest.Status, src => src.Status.ToString());
        
        config.NewConfig<OrderItem, CustomerOrderItems>();

        var response = customerOrders.Adapt<IEnumerable<GetCustomerOrdersResponse>>(config);


        return new DataResult<GetCustomerOrdersResponse>(response.ToList());
    }
}
