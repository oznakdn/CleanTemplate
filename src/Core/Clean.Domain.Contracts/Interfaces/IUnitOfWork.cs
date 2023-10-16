namespace Clean.Domain.Contracts.Interfaces;

public interface IUnitOfWork : IAsyncDisposable
{
    Task<int> SaveAsync(CancellationToken cancellationToken = default(CancellationToken));
}
