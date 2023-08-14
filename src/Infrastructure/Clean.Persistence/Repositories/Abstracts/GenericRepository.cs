using AutoMapper;
using Clean.Domain.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clean.Persistence.Repositories.Abstracts;

public abstract class GenericRepository<TEntity, TContext, TKey> : IGenericRepository<TEntity, TKey>
where TEntity : Entity<TKey>, new()
where TContext : DbContext
{
    protected readonly TContext _dbContext;
    public IMapper _mapper { get; }

    private DbSet<TEntity> _table;

    private IQueryable<TEntity> _query;

    public GenericRepository(TContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _table = _dbContext.Set<TEntity>();
        _query = _query!.AsNoTracking();
    }

    public virtual void Delete(TEntity entity)
    {
        _table.Remove(entity);
        Save();
    }

    public virtual void Insert(TEntity entity)
    {
        _table.Add(entity);
        Save();
    }

    public virtual void Update(TEntity entity)
    {
        _table.Update(entity);
        Save();
    }



    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate, params Expression<Func<TEntity, object>>[] includeProperties)
    {
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
        _query.Where(predicate);

        if (includeProperties.Length > 0)
        {
            foreach (var property in includeProperties)
            {
                _query = _query.Include(property);
            }
        }
        return await _query.SingleOrDefaultAsync();
    }

    public virtual IQueryable<TEntity> GetQueryable() => _query;




    public virtual void Save() => _dbContext.SaveChanges();

    public virtual async Task SaveAsync() => await _dbContext.SaveChangesAsync();

    public virtual async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();

}
