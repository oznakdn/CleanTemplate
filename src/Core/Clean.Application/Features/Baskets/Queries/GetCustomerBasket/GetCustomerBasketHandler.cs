using Clean.Application.Results;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Baskets.Queries.GetCustomerBasket;

public record GetCustomerBasketRequest(string CustomerId) : IRequest<GetCustomerBasketResponse>;
public record GetBasketItems(string ProductName, int Quantity, decimal TotalPrice);
public class GetCustomerBasketResponse : Response
{
    public string BasketId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<GetBasketItems> BasketItems { get; set; }
}
public class GetCustomerBasketHandler : IRequestHandler<GetCustomerBasketRequest, GetCustomerBasketResponse>
{
    private readonly IBasketRepository _basket;
    private readonly IProductRepository _product;
    public GetCustomerBasketHandler(IBasketRepository basket, IProductRepository product)
    {
        _basket = basket;
        _product = product;
    }

    public async Task<GetCustomerBasketResponse> Handle(GetCustomerBasketRequest request, CancellationToken cancellationToken)
    {
        GetCustomerBasketResponse response = new();
        var basket = await _basket.GetAsync(cancellationToken, x => x.CustomerId == Guid.Parse(request.CustomerId));

        var products = await _product.GetAllAsync(cancellationToken);

        if (basket is null)
        {
            response.Successed = false;
            response.Message = "Basket not found!";
            return response;
        }

        response.BasketId = basket.Id.ToString();

        if (basket.BasketItems.Count > 0)
        {
            response.BasketItems = basket.BasketItems
                .Select(x => new GetBasketItems(
                    ProductName: products.SingleOrDefault(y => y.Id == x.ProductId)!.DisplayName,
                    Quantity: x.ProductQuantity,
                    TotalPrice: x.Basket.TotalAmount
                )).ToList();
        }

        return response;
    }
}
