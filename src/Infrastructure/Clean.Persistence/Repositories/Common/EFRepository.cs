﻿using Clean.Domain.Contracts.Interfaces;

namespace Clean.Persistence.Repositories.Common;

public abstract class EFRepository<TEntity, TContext, TId> : IEFRepository<TEntity, TId>
where TEntity : class, IEntity<TId>
where TContext : DbContext
{
    protected readonly TContext _dbContext;
    private DbSet<TEntity> _table;
    public EFRepository(TContext dbContext)
    {
        _dbContext = dbContext;
        _table = _dbContext.Set<TEntity>();
    }

    #region Insert

    public virtual void Insert(TEntity entity)
    {
        _table.Add(entity);
    }

    public virtual async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _table.AddAsync(entity, cancellationToken);
        return entity;
    }

    #endregion

    #region Update
    public virtual void Update(TEntity entity)
    {
        _table.Update(entity);
    }
    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await Task.Run(() => _table.Update(entity), cancellationToken);
        return entity;
    }

    #endregion

    #region Delete

    public virtual void Delete(TEntity entity)
    {
        _table.Remove(entity);
    }

    public async Task<TEntity?> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await Task.Run(() => _table.Remove(entity), cancellationToken);
        return entity;
    }

    #endregion

    #region Save
    public async Task<int> SaveAsync(CancellationToken cancellationToken = default) => await _dbContext.SaveChangesAsync(cancellationToken);
    public int Save() => _dbContext.SaveChanges();

    #endregion


    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, 
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> _query = _table;
        _query = predicate != null ? _query.Where(predicate) : _query;

        if (includeProperties.Length > 0)
        {
            foreach (var property in includeProperties)
            {
                _query = _query.Include(property);
            }
        }

        return _query.AsNoTracking().ToList();
    }


    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken,
        Expression<Func<TEntity, bool>> predicate = null,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> _query = _table;
        _query = predicate != null ? _query.Where(predicate) : _query;

        if (includeProperties.Length > 0)
        {
            foreach (var property in includeProperties)
            {
                _query = _query.Include(property);
            }
        }

        return await _query.AsNoTracking().ToListAsync(cancellationToken);
    }

    public TEntity GetAsync(Expression<Func<TEntity, bool>> predicate, 
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> _query = _table;
        _query = _query.Where(predicate);

        if (includeProperties.Length > 0)
        {
            foreach (var property in includeProperties)
            {
                _query = _query.Include(property);
            }
        }
        return _query.AsNoTracking().SingleOrDefault();
    }

    public virtual async Task<TEntity> GetAsync(CancellationToken cancellation,
        Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> _query = _table;
        _query = _query.Where(predicate);

        if (includeProperties.Length > 0)
        {
            foreach (var property in includeProperties)
            {
                _query = _query.Include(property);
            }
        }
        return await _query.AsNoTracking().SingleOrDefaultAsync(cancellation);
    }

    public virtual IQueryable<TEntity> GetQueryable() => _table.AsQueryable();


    public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();

   
}
