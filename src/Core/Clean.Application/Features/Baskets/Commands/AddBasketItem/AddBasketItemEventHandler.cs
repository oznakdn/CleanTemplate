using Clean.Domain.Baskets;
using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Products;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Baskets.Commands.AddBasketItem;


public class AddBasketItemEvent : IDomaintEvent
{
    public AddBasketItemEvent(Basket basket, Product product, int quantity)
    {
        Basket = basket;
        Product = product;
        Quantity = quantity;
    }

    public BasketItem BasketItem { get; set; }
    public Basket Basket { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}


public class AddBasketItemEventHandler : DomainEventHandler<AddBasketItemEvent, BasketItem>
{
    private readonly IBasketItemRepository _basketItem;

    public AddBasketItemEventHandler(IBasketItemRepository basketItem)
    {
        _basketItem = basketItem;
    }

    protected override async Task<BasketItem> Handle(AddBasketItemEvent @event, CancellationToken cancellationToken)
    {
        Event += (s, e) => _basketItem.Insert(@event.BasketItem =
            new BasketItem(e.Basket.Id, e.Product.Id, e.Quantity, e.Product.Price.Amount));
        this.OnStarted(@event);
        await Task.CompletedTask;
        return @event.BasketItem;
    }
}
