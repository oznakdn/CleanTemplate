using Clean.Domain.Contracts.ValueObjects;

namespace Clean.Domain.ValueObjects;

public class Inventory : ValueObject
{
    public Inventory(int amount)
    {
        Amount = amount;
        HasStock = amount > 0 ? true : false;
    }
    private Inventory() { }

    public int Amount { get; internal set; }
    public bool HasStock { get; }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Amount;
        yield return HasStock;
    }
}
