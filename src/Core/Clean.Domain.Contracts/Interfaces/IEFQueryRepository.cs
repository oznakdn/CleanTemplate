using Clean.Domain.Contracts.Abstracts;
using System.Linq.Expressions;

namespace Clean.Domain.Contracts.Interfaces;

public interface IEFQueryRepository<T, TId>
    where T : Entity<TId>
{
    Task<IQueryable<T>> QueryAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties);

    public Task<IEnumerable<T>> ReadAllAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties);


    Task<T> ReadSingleOrDefaultAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties);


    Task<T> ReadFirstOrDefaultAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties);

    Task<T> ReadLastOrDefaultAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties);


    Task<T> ReadFirstAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties);

    Task<T> ReadLastAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties);

    Task<T> ReadSingleAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties);

    Task<bool> ExistAsync(
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default);



    IQueryable<T> Query(
        bool noTracking,
        Expression<Func<T, bool>> filter = null,
        params Expression<Func<T, object>>[] includeProperties);

    IEnumerable<T> ReadAll(
        bool noTracking,
        Expression<Func<T, bool>> filter = null,
        params Expression<Func<T, object>>[] includeProperties);

    T ReadSingleOrDefault(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includeProperties);

    T ReadFirstOrDefault(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includeProperties);

    T ReadLastOrDefault(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includeProperties);

    T ReadFirst(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includeProperties);

    T ReadLast(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includeProperties);

    T ReadSingle(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includeProperties);

    bool Exist(Expression<Func<T, bool>> filter);

    Task<IQueryable<T>> QueryFilterAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default);

    Task<IQueryable<T>> QueryFilterAndIncludeAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        Expression<Func<T, object>>[] includeProperties,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> ReadAllWithPaginationAsync(
        bool noTracking,
        int pageSize = 10,
        int PageNumber = 1,
        Expression<Func<T, bool>> filter = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties);

    Task<IEnumerable<T>> ReadAllWithFilterAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> ReadAllWithFilterAndIncludeAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        Expression<Func<T, object>>[] includeProperties,
        CancellationToken cancellationToken = default);

    IQueryable<T> QueryFilter(
       bool noTracking,
       Expression<Func<T, bool>> filter);

    IQueryable<T> QueryFilterAndInclude(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        Expression<Func<T, object>>[] includeProperties);

    IEnumerable<T> ReadAllWithPagination(
        bool noTracking,
        int pageSize = 10,
        int PageNumber = 1,
        Expression<Func<T, bool>> filter = null,
        params Expression<Func<T, object>>[] includeProperties);


}
