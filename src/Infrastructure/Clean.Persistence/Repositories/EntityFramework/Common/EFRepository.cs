namespace Clean.Persistence.Repositories.EntityFramework.Common;

public abstract class EFRepository<TEntity, TContext, TKey> : IEFRepository<TEntity, TKey>
where TEntity : Entity<TKey>, new()
where TContext : DbContext
{
    protected readonly TContext _dbContext;
    private DbSet<TEntity> _table;
    public EFRepository(TContext dbContext)
    {
        _dbContext = dbContext;
        _table = _dbContext.Set<TEntity>();
    }

    public virtual void Delete(TEntity entity)
    {
        _table.Remove(entity);
    }

    public virtual void Insert(TEntity entity)
    {
        _table.Add(entity);
    }

    public virtual void Update(TEntity entity)
    {
        _table.Update(entity);
    }



    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate, params Expression<Func<TEntity, object>>[] includeProperties)
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

        return await _query.ToListAsync();
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
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
        return await _query.SingleOrDefaultAsync();
    }

    public virtual IQueryable<TEntity> GetQueryable() => _table.AsQueryable();

}
