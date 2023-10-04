using Clean.Domain.Contracts.ValueObjects;

namespace Clean.Domain.ValueObjects;

public class Inventory : ValueObject
{
    public Inventory(int amount, bool hasStock)
    {
        Amount = amount;
        HasStock = hasStock;
    }
    private Inventory() { }

    public int Amount { get; private set; }
    public bool HasStock { get; private set; }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Amount; 
        yield return HasStock;
    }
}
