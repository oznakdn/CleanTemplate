# Domain Driven Design

## ABSTRACTS
### Entity
```csharp
public abstract class Entity<TId> : IEntity<TId>
{
    public virtual TId Id { get;}

    public bool IsDeleted { get; }

    public Entity(TId id)
    {
        if (!IsValid(id))
            throw new ArgumentException("Identifier format is wrong!");
        Id = id;
        IsDeleted = true;
    }


    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity<TId>);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(IEntity<TId>? other)
    {
        return Id.GetHashCode() == other.GetHashCode();
    }

    public static bool operator ==(Entity<TId> lhs, Entity<TId> rhs)
    {
        return lhs.Equals(rhs);
    }

    public static bool operator !=(Entity<TId> lhs, Entity<TId> rhs)
    {
        return !(lhs == rhs);
    }

    private bool IsValid(TId id)
    {
        return id is int || id is long || id is Guid;
    }
}
```

### Aggregate Root
```csharp
public abstract class AggregateRoot<T, TId> : IEntity<TId>
where T : IEntity<TId>
{
    public virtual TId Id { get; set; }
    public bool IsDeleted { get; set; } = false;

    public AggregateRoot(TId id)
    {
        if (!IsValid(id))
            throw new ArgumentException("Identifier format is wrong!");
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity<TId>);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(IEntity<TId>? other)
    {
        return Id.GetHashCode() == other.GetHashCode();
    }

    public static bool operator ==(AggregateRoot<T, TId> lhs, AggregateRoot<T, TId> rhs)
    {
        return lhs.Equals(rhs);
    }

    public static bool operator !=(AggregateRoot<T, TId> lhs, AggregateRoot<T, TId> rhs)
    {
        return !(lhs == rhs);
    }

    private bool IsValid(TId id)
    {
        return id is int || id is long || id is Guid;
    }
}
```

### Value Object
```csharp
public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetAtomicValues();
    public bool Equals(ValueObject other)
    {
        if (other == null || other.GetType() != GetType()) return false;

        var thisValues = GetAtomicValues().GetEnumerator();
        var otherValues = other.GetAtomicValues().GetEnumerator();

        while (thisValues.MoveNext() && otherValues.MoveNext())
        {
            if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current)) return false;
        }

        return !thisValues.MoveNext() && !otherValues.MoveNext();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ValueObject);
    }

    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return left != null && left.Equals(right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !(left == right);
    }
}
```

### Domain Event
```csharp
public interface IDomaintEvent
{
}
```
```csharp
public abstract class DomainEventHandler<TDomainEvent, TResponse>
where TDomainEvent : IDomaintEvent
where TResponse : class
{
    protected event EventHandler<TDomainEvent> Event;
    protected TResponse Response { get; set; }
    protected abstract Task<TResponse> Handle(TDomainEvent @event, CancellationToken cancellationToken);
    protected void EventInvoke(TDomainEvent @event) => Event.Invoke(this, @event);

    public async Task<TResponse> Publish(TDomainEvent @event, CancellationToken cancellationToken) => await Handle(@event, cancellationToken);

}
```
<hr>

## DOMAINS
### Product Aggregate Root
```csharp
public class Product : AggregateRoot<Product, Guid>
{
    public string DisplayName { get; private set; }
    public Money Price { get; private set; }
    public Inventory Inventory { get; private set; }
    public Category Category { get; private set; }


    public Product(string displayName) : base(Guid.NewGuid())
    {
        DisplayName = displayName;
    }

    private Product() : base(Guid.Empty) { }


    public Result AddMoney(Currency currency, decimal amount)
    {
        var errors = new List<string>();

        if (currency < 0)
        {
            errors.Add($"{nameof(Price.Currency)} cannot be less than 0!");
        }

        if (amount < 0)
        {
            errors.Add($"{nameof(Price.Amount)} cannot be less than 0!");

        }
     
        if(errors.Count > 0) 
        {
            return Result.Fail(errors);
        }

        Price = new Money(currency, amount);
        return  Result.Ok();
    }

    public Result AddCategory(string displayName)
    {
        if (displayName.Length < 3 || displayName.Length > 20)
        {
            return Result.Fail($"{nameof(Category.DisplayName)} can be between 3 and 20 characters!");
        }

        Category = new Category(displayName);
        return  Result.Ok();

    }

    public Result AddInventory(Guid productId, int quantity)
    {
        if (quantity < 0)
            return  Result.Fail("Quantity cannot be less than 0!");

        Inventory = new(productId, quantity);
        return  Result.Ok();
    }

}
```
### Inventory Entity
```csharp
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
        if(Quantity == 0)
        {
            HasStock = false;
        }
    }

    public void IncreaseStock(int quantity)
    {
        Quantity += quantity;
    }
}
```
### Category Value Object
```csharp
public class Category : ValueObject
{
    public string DisplayName { get; private set; }

    public Category(string displayName)
    {
        DisplayName = displayName;
    }

    private Category() { }

    public void Update(string newName)
    {
        DisplayName = newName;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return DisplayName;
    }
}
```
### Money Value Object
```csharp
public class Money : ValueObject
{
    public Money(Currency moneyType, decimal amount)
    {
        Currency = moneyType;
        Amount = amount;
    }

    private Money() { }

    public Currency Currency { get; private set; }
    public decimal Amount { get; private set; }


    public void UpdateMoneyType(Currency moneyType)
    {
        Currency = moneyType;
    }

    public void UpdateMoneyAmount(decimal amount)
    {
        Amount = amount;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Currency.ToString();
        yield return Amount;
    }
}
```
### Currency Enum
```csharp
public enum Currency
{
    TL,
    DOLAR,
    EURO,
}
```
<hr>
