using Clean.Domain.BasketItems;
using Clean.Domain.Baskets;
using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Products;

namespace Clean.Domain.BasketItems.Events;

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

