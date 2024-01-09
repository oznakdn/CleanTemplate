using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Inventories;

public class Inventory : Entity<Guid>
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public bool HasStock { get; private set; }

    public Inventory(Guid productId, int quantity) : base(Guid.NewGuid())
    {
        ProductId = productId;
        Quantity = quantity;
        HasStock = Quantity > 0 ? true : false;
    }

    public void DecreaseStock(int quantity)
    {
        Quantity -= quantity;
        if (Quantity == 0)
        {
            HasStock = false;
        }
    }

    public void IncreaseStock(int quantity)
    {
        Quantity += quantity;
    }

    public void UpdateInventory(int? quantity)
    {
        Quantity = quantity ?? Quantity;
        if (quantity > 0)
        {
            HasStock = true;
        }
    }

}
