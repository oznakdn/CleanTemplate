using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Contracts.Interfaces;

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
