using Clean.Application.UnitOfWork.Queries;
using Clean.Shared;


namespace Clean.Application.Features.Baskets.Queries.GetCustomerBasket;

public record GetCustomerBasketRequest(string CustomerId) : IRequest<IResult<GetCustomerBasketResponse>>;
public record GetBasketItems(string Id, string ProductName, int Quantity);
public class GetCustomerBasketResponse
{
    public string BasketId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<GetBasketItems> BasketItems { get; set; }
}
public class GetCustomerBasketHandler : IRequestHandler<GetCustomerBasketRequest, IResult<GetCustomerBasketResponse>>
{
    private readonly IQueryUnitOfWork _query;

    public GetCustomerBasketHandler(IQueryUnitOfWork query)
    {
        _query = query;
    }

    public async Task<IResult<GetCustomerBasketResponse>> Handle(GetCustomerBasketRequest request, CancellationToken cancellationToken)
    {
        GetCustomerBasketResponse response = new();
        var basket = await _query.Basket.ReadSingleOrDefaultAsync(true, x => x.CustomerId == Guid.Parse(request.CustomerId), cancellationToken);
        var basketItems = await _query.BasketItem.ReadAllAsync(true,
            filter: x => x.BasketId == basket.Id, cancellationToken: cancellationToken);

        if (basket is null)
            return Result<GetCustomerBasketResponse>.Fail("Basket not found!");


        response.BasketId = basket.Id.ToString();
        response.TotalAmount = basket.TotalAmount;

        response.BasketItems = basketItems.Select(x => new GetBasketItems(
            x.Id.ToString(),
            _query.Product.ReadSingleOrDefault(true, y => y.Id == x.ProductId).DisplayName,
            x.ProductQuantity
            )).ToList();

        return Result<GetCustomerBasketResponse>.Success(value:response);
    }
}
