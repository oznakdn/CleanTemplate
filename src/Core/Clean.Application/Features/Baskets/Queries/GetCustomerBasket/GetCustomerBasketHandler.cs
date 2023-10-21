using Clean.Application.Results;
using Clean.Application.UnitOfWork.Commands;
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
    private readonly IQueryUnitOfWork _query;
    private readonly ICommandUnitOfWork _command;

    public GetCustomerBasketHandler(IQueryUnitOfWork query, ICommandUnitOfWork command)
    {
        _query = query;
        _command = command;
    }

    public async Task<GetCustomerBasketResponse> Handle(GetCustomerBasketRequest request, CancellationToken cancellationToken)
    {
        GetCustomerBasketResponse response = new();
        var basket = await _query.Basket.ReadSingleOrDefaultAsync(true, x => x.CustomerId == Guid.Parse(request.CustomerId), cancellationToken);
        var basketItems = await _query.BasketItem.ReadAllAsync(true,
            filter: x => x.BasketId == basket.Id, cancellationToken: cancellationToken);


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
            _query.Product.ReadSingleOrDefault(true, y => y.Id == x.ProductId).DisplayName,
            x.ProductQuantity
            )).ToList();

        return response;
    }
}
