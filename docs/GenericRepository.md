# Generic Repository

## EF Core
```csharp
public interface IEFCommandRepository<T,TId>:IAsyncDisposable,IDisposable
    where T:Entity<TId>
{
    // Create
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));
    T Create(T entity);
    void Insert(T entity);
    IEnumerable<T> CreateRange(IEnumerable<T> entities);
    void InsertRange(IEnumerable<T> entities);

    // Update
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task EditAsync(T entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task EditRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    T Update(T entity);
    void Edit(T entity);
    IEnumerable<T> UpdateRange(IEnumerable<T> entities);
    void EditRange(IEnumerable<T> entities);

    // Delete
    Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
    Task RemoveAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));
    Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));
    T Delete(T entity);
    void Remove(T entity);
    IEnumerable<T> DeleteRange(IEnumerable<T> entities);
    void RemoveRange(IEnumerable<T> entities);

    // Save
    Task<int> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken));
    int Execute();
}
```

```csharp
public interface IEFQueryRepository<T, TId>
    where T : Entity<TId>
{
    Task<IQueryable<T>> QueryAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties);

     Task<IEnumerable<T>> ReadAllAsync(
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

```

## Mongo Driver
```csharp
public interface IMongoCommandRepository<TCollection>
    where TCollection : IDocument
{

    // Create

    Task<TCollection> CreateAsync(TCollection document, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertAsync(TCollection document, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<TCollection>> CreateRangeAsync(IEnumerable<TCollection> documents, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertRangeAsync(IEnumerable<TCollection> documents, CancellationToken cancellationToken = default(CancellationToken));
    TCollection Create(TCollection document);
    void Insert(TCollection document);
    IEnumerable<TCollection> CreateRange(IEnumerable<TCollection> documents);
    void InsertRange(IEnumerable<TCollection> documents);

    // Update

    Task<TCollection> UpdateAsync(FilterDefinition<TCollection> filter, TCollection collection, CancellationToken cancellationToken = default);
    Task EditAsync(FilterDefinition<TCollection> filter, TCollection collection, CancellationToken cancellationToken = default);
    Task EditRangeAsync(FilterDefinition<TCollection> filter, UpdateDefinition<TCollection> update, CancellationToken cancellationToken = default);
    TCollection Update(FilterDefinition<TCollection> filter, TCollection collection);
    void Edit(FilterDefinition<TCollection> filter, TCollection collection);
    void EditRange(FilterDefinition<TCollection> filter, UpdateDefinition<TCollection> update);


    // Delete

    Task DeleteAsync(FilterDefinition<TCollection> filter, CancellationToken cancellationToken = default(CancellationToken));
    Task DeleteRangeAsync(FilterDefinition<TCollection> filter, CancellationToken cancellationToken = default(CancellationToken));
    void Delete(FilterDefinition<TCollection> filter);
    void DeleteRange(FilterDefinition<TCollection> filter);

}
```

```csharp
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
```
