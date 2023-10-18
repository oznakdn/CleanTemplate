using Clean.Application.Results;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Baskets.Queries.GetCustomerBasket;

public record GetCustomerBasketRequest(string CustomerId) : IRequest<GetCustomerBasketResponse>;
public record GetBasketItems(string ProductName, int Quantity);
public class GetCustomerBasketResponse : Response
{
    public string BasketId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<GetBasketItems> BasketItems { get; set; }
}
public class GetCustomerBasketHandler : IRequestHandler<GetCustomerBasketRequest, GetCustomerBasketResponse>
{
    private readonly IBasketRepository _basket;
    private readonly IBasketItemRepository _basketItem;
    private readonly IProductRepository _product;
    public GetCustomerBasketHandler(IBasketRepository basket, IProductRepository product, IBasketItemRepository basketItem)
    {
        _basket = basket;
        _product = product;
        _basketItem = basketItem;
    }

    public async Task<GetCustomerBasketResponse> Handle(GetCustomerBasketRequest request, CancellationToken cancellationToken)
    {
        GetCustomerBasketResponse response = new();
        var basket = await _basket.GetAsync(cancellationToken, x => x.CustomerId == Guid.Parse(request.CustomerId));
        var basketItems = await _basketItem.GetAllAsync(cancellationToken, x => x.BasketId == basket.Id);


        if (basket is null)
        {
            response.Successed = false;
            response.Message = "Basket not found!";
            return response;
        }

        response.BasketId = basket.Id.ToString();
        response.TotalAmount = basket.TotalAmount;

        response.BasketItems = basketItems.Select(x => new GetBasketItems(
            _product.GetAsync(cancellationToken, y => y.Id == x.ProductId).Result.DisplayName,
            x.ProductQuantity
            )).ToList();

        return response;
    }
}
