using Clean.Domain.Contracts.Events;
using Clean.Domain.Events;

namespace Clean.Application.Features.Commands.ProductCommands.Remove;

public class ProductDeletedEventHandler : IDomainEventHandler<ProductDeletedDomainEvent>
{
    private readonly IEfUnitOfWork _efUnitOfWork;

    public ProductDeletedEventHandler(IEfUnitOfWork efUnitOfWork)
    {
        _efUnitOfWork = efUnitOfWork;
    }

    public async Task Handle(ProductDeletedDomainEvent notification, CancellationToken cancellationToken)
    {
        _efUnitOfWork.Product.Delete(notification.Product);
        await Task.CompletedTask;
    }
}
