using Clean.Application.Results;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Baskets.Queries.GetCustomerBasket;

public record GetCustomerBasketRequest(string CustomerId) : IRequest<GetCustomerBasketResponse>;
public record GetBasketItems(string Id, string ProductName, int Quantity);
public class GetCustomerBasketResponse : Response
{
    public string BasketId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<GetBasketItems> BasketItems { get; set; }
}
public class GetCustomerBasketHandler : IRequestHandler<GetCustomerBasketRequest, GetCustomerBasketResponse>
{
    private readonly IBasketRepository _basket;
    private readonly IQueryUnitOfWork _query;
    private readonly IProductRepository _product;
    public GetCustomerBasketHandler(IBasketRepository basket, IProductRepository product, IQueryUnitOfWork query)
    {
        _basket = basket;
        _product = product;
        _query = query;
    }

    public async Task<GetCustomerBasketResponse> Handle(GetCustomerBasketRequest request, CancellationToken cancellationToken)
    {
        GetCustomerBasketResponse response = new();
        var basket = await _basket.GetAsync(cancellationToken, x => x.CustomerId == Guid.Parse(request.CustomerId));
        var basketItems = await _query.BasketItem.ReadAllAsync(true,
            filter: x => x.BasketId == basket.Id,cancellationToken:cancellationToken);


        if (basket is null)
        {
            response.Successed = false;
            response.Message = "Basket not found!";
            return response;
        }

        response.BasketId = basket.Id.ToString();
        response.TotalAmount = basket.TotalAmount;

        response.BasketItems = basketItems.Select(x => new GetBasketItems(
            x.Id.ToString(),
            _product.GetAsync(cancellationToken, y => y.Id == x.ProductId).Result.DisplayName,
            x.ProductQuantity
            )).ToList();

        return response;
    }
}
