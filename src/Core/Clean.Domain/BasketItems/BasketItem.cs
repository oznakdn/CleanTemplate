using Clean.Domain.Baskets;
using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.BasketItems;

public class BasketItem : Entity<Guid>
{

    public Guid BasketId { get; private set; }
    public Guid ProductId { get; private set; }
    public int ProductQuantity { get; private set; }
    public decimal ProductPrice { get; private set; }
    public Basket Basket { get; private set; }

    public BasketItem(Guid basketId, Guid productId, int productQuantity, decimal productPrice) : base(Guid.NewGuid())
    {
        BasketId = basketId;
        ProductId = productId;
        ProductQuantity = productQuantity;
        ProductPrice = productPrice;
    }

    private BasketItem() : base(Guid.Empty)
    {
    }

    public void UpdateQuantity(int quantity)
    {
        ProductQuantity += quantity;
        if (ProductQuantity < 0)
        { ProductQuantity = 0; }
    }

}
