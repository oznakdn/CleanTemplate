# Unit Of Work Pattern

## Interfaces
```csharp
public interface IQueryUnitOfWork
{
    IBasketItemQuery BasketItem { get; }
    IBasketQuery Basket { get; }
    ICustomerQuery Customer { get; }
    IProductQuery Product { get; }
    IInventoryQuery Inventory { get; }
    IOrderQuery Order { get; }
    IOrderItemQuery OrderItem { get; }
}
```

```csharp
public interface ICommandUnitOfWork
{
    IBasketItemCommand BasketItem { get; }
    IBasketCommand Basket { get; }
    ICustomerCommand Customer { get; }
    IProductCommand Product { get; }
    IInventoryCommand Inventory { get; }
    IOrderCommand Order { get; }
    IOrderItemCommand OrderItem { get; }
}
```
## Concretes
```csharp
public class QueryUnitOfWork : IQueryUnitOfWork
{

    private readonly ApplicationDbContext _context;

    public QueryUnitOfWork(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        BasketItem = BasketItem ?? new BasketItemQuery(_context);
        Basket = Basket ?? new BasketQuery(_context);
        Customer = Customer ?? new CustomerQuery(_context);
        Product = Product ?? new ProductQuery(_context);
        Inventory = Inventory ?? new InventoryQuery(_context);
        Order = Order ?? new OrderQuery(_context);
        OrderItem = OrderItem ?? new OrderItemQuery(_context);
    }

    public IBasketItemQuery BasketItem { get; }
    public IBasketQuery Basket { get; }
    public ICustomerQuery Customer { get; }
    public IProductQuery Product { get; }
    public IInventoryQuery Inventory { get; }
    public IOrderQuery Order { get; }
    public IOrderItemQuery OrderItem { get; }
}
```
```csharp
public class CommandUnitOfWork : ICommandUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public CommandUnitOfWork(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        BasketItem = BasketItem ?? new BasketItemCommand(_context);
        Basket = Basket ?? new BasketCommand(_context);
        Customer = Customer ?? new CustomerCommand(_context);
        Product = Product ?? new ProductCommand(_context);
        Inventory = Inventory ?? new InventoryCommand(_context);
        Order = Order ?? new OrderCommand(_context);
        OrderItem = OrderItem ?? new OrderItemCommand(_context);
    }

    public IBasketItemCommand BasketItem { get; }
    public IBasketCommand Basket { get; }
    public ICustomerCommand Customer { get; }
    public IProductCommand Product { get; }
    public IInventoryCommand Inventory { get; }
    public IOrderCommand Order { get; }
    public IOrderItemCommand OrderItem { get; }
}
```
