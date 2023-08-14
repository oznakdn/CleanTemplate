using AutoMapper;
using Clean.Domain.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clean.Persistence.Repositories;

public class GenericRepository<TEntity, TContext, TKey> : IGenericRepository<TEntity, TKey>
where TEntity : Entity<TKey>, new()
where TContext : DbContext
{
    protected DbContext _dbContext { get; }
    public IMapper _mapper { get; }

    private DbSet<TEntity> _table;

    private IQueryable<TEntity> _query;

    public GenericRepository(DbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _table = _dbContext.Set<TEntity>();
        _query = _query!.AsNoTracking();
    }

    public void Delete(TEntity entity)
    {
        _table.Remove(entity);
        Save();
    }

    public void Insert(TEntity entity)
    {
        _table.Add(entity);
        Save();
    }

    public void Update(TEntity entity)
    {
        _table.Update(entity);
        Save();
    }



    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate, params Expression<Func<TEntity, object>>[] includeProperties)
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

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
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

    public IQueryable<TEntity> GetQueryable() => _query;
  



    public void Save() => _dbContext.SaveChanges();

    public Task SaveAsync() => _dbContext.SaveChangesAsync();

    public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();

}
