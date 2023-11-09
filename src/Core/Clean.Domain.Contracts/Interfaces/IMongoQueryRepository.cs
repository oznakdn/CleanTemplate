using System.Linq.Expressions;

namespace Clean.Domain.Contracts.Interfaces;

public interface IMongoQueryRepository<TCollection>
    where TCollection : IDocument
{
    Task<IEnumerable<TCollection>> ReadAllAsync(CancellationToken cancellationToken = default(CancellationToken),
        Expression<Func<TCollection, bool>> filter = null);

    Task<IEnumerable<TCollection>> ReadAllWithPaginationAsync(
      int pageSize = 10, int pageNumber = 1,
      CancellationToken cancellationToken = default(CancellationToken),
      Expression<Func<TCollection, bool>> filter = null);

    Task<TCollection> ReadSingleOrDefaultAsync(Expression<Func<TCollection, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken));

    Task<TCollection> ReadFirstOrDefaultAsync(Expression<Func<TCollection, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken));

    Task<TCollection> ReadSingleAsync(Expression<Func<TCollection, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken));

    Task<TCollection> ReadFirstAsync(Expression<Func<TCollection, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken));

    IEnumerable<TCollection> ReadAll(Expression<Func<TCollection, bool>> filter = null);
    IEnumerable<TCollection> ReadAllWithPagination(int pageSize = 10, int pageNumber = 1, Expression<Func<TCollection, bool>> filter = null);
    TCollection ReadSingleOrDefault(Expression<Func<TCollection, bool>> filter);
    TCollection ReadFirstOrDefaut(Expression<Func<TCollection, bool>> filter);
    TCollection ReadSingle(Expression<Func<TCollection, bool>> filter);
    TCollection ReadFirst(Expression<Func<TCollection, bool>> filter);
}
