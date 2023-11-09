using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;

namespace Clean.Persistence.Repositories.EntityFramework.Common;

public abstract class EFCommandRepository<T, TContext, TId> : IEFCommandRepository<T, TId>
    where T : Entity<TId>
    where TContext : DbContext
{

    protected readonly EFContext _context;
    private readonly DbSet<T> _table;
    public EFCommandRepository(EFContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    // Create
    public virtual async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _table.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual async Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await _table.AddRangeAsync(entities, cancellationToken);
        return entities;
    }

    public virtual async Task InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _table.AddAsync(entity, cancellationToken);
    }

    public virtual async Task InsertRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await _table.AddRangeAsync(entities, cancellationToken);
    }

    public virtual T Create(T entity)
    {
        _table.Add(entity);
        return entity;
    }

    public virtual void Insert(T entity) => _table.Add(entity);

    public virtual IEnumerable<T> CreateRange(IEnumerable<T> entities)
    {
        _table.AddRange(entities);
        return entities;
    }

    public virtual void InsertRange(IEnumerable<T> entities) => _table.AddRange(entities);

    // Update

    public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.Update(entity), cancellationToken);
        return entity;
    }

    public virtual async Task EditAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.Update(entity), cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.UpdateRange(entities), cancellationToken);
        return entities;
    }

    public virtual async Task EditRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.UpdateRange(entities), cancellationToken);
    }

    public virtual T Update(T entity)
    {
        _table.Update(entity);
        return entity;
    }

    public virtual void Edit(T entity) => _table.Update(entity);

    public virtual IEnumerable<T> UpdateRange(IEnumerable<T> entities)
    {
        _table.UpdateRange(entities);
        return entities;

    }

    public virtual void EditRange(IEnumerable<T> entities) => _table.UpdateRange(entities);


    // Delete

    public virtual async Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.Remove(entity), cancellationToken);
        return entity;
    }

    public virtual async Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.Remove(entity), cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.RemoveRange(entities), cancellationToken);
        return entities;
    }

    public virtual async Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _table.RemoveRange(entities), cancellationToken);
    }

    public virtual T Delete(T entity)
    {
        _table.Remove(entity);
        return entity;
    }

    public virtual void Remove(T entity)
    {
        _table.Remove(entity);

    }

    public virtual IEnumerable<T> DeleteRange(IEnumerable<T> entities)
    {
        _table.RemoveRange(entities);
        return entities;
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _table.RemoveRange(entities);
    }


    // Save
    public async Task<int> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken)) => await _context.SaveChangesAsync(cancellationToken);
    public int Execute() => _context.SaveChanges();


    // Dispose

    public async ValueTask DisposeAsync() => await _context.DisposeAsync(); 
 
    public void Dispose() => _context.Dispose();
 
}
