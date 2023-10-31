using Clean.Domain.Baskets;

namespace DomainTests;

public class BasketTests
{
    Guid CustomerId { get; set; } = Guid.NewGuid();
    Guid ProductId { get; set; } = Guid.NewGuid();

    [Fact]
    public void CreateBasket_Should_Change_TotalAmount()
    {
        Basket basket = new(CustomerId);
        Assert.NotNull(basket);
    }

    [Fact]
    public void AddBasketItem_Should_Change_TotalAmount()
    {
        Basket basket = new(CustomerId);
        basket.AddBasketItem(new BasketItem(basket.Id,ProductId,2,100));
        Assert.Equal<decimal>(basket.TotalAmount,200);
        
    }

    [Fact]
    public void RemoveBasketItem_Should_Change_TotalAmount()
    {
        Basket basket = new(CustomerId);
        BasketItem basketItem = new(basket.Id, ProductId, 2, 100);
        basket.AddBasketItem(basketItem);
        basket.RemoveBasketItem(basketItem);

        Assert.Equal<decimal>(basket.TotalAmount, 0);

    }

    [Fact]
    public void UpdateBasketItemQuantity_Should_Increase_TotalAmount()
    {
        Basket basket = new(CustomerId);
        BasketItem basketItem = new(basket.Id, ProductId, 2, 100);
        basket.AddBasketItem(basketItem);
        basket.UpdateBasketItemQuantity(basketItem.ProductPrice,1);

        Assert.Equal<decimal>(basket.TotalAmount, 300);

    }

    [Fact]
    public void UpdateBasketItemQuantity_Should_Decrease_TotalAmount()
    {
        Basket basket = new(CustomerId);
        BasketItem basketItem = new(basket.Id, ProductId, 2, 100);
        basket.AddBasketItem(basketItem);
        basket.UpdateBasketItemQuantity(basketItem.ProductPrice, -1);

        Assert.Equal<decimal>(basket.TotalAmount, 100);

    }

    [Fact]
    public void ClearTotalAmount_Should_Return_Zero()
    {
        Basket basket = new(CustomerId);
        BasketItem basketItem = new(basket.Id, ProductId, 2, 100);
        basket.AddBasketItem(basketItem);
        basket.ClearTotalAmount();

        Assert.Equal<decimal>(basket.TotalAmount, 0);

    }
}
