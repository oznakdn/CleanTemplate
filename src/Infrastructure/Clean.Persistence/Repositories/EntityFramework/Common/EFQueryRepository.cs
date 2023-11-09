using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;

namespace Clean.Persistence.Repositories.EntityFramework.Common;

public abstract class EFQueryRepository<T, TContext, TId> : IEFQueryRepository<T, TId>
    where T : Entity<TId>
    where TContext : DbContext
{
    protected readonly TContext _context;
    private readonly DbSet<T> _table;

    protected EFQueryRepository(TContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    #region Async Reading

    public virtual async Task<IQueryable<T>> QueryAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table;
        query = filter is null ? query : query.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await Task.Run(() => query.AsQueryable(), cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> ReadAllAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table;
        query = filter is null ? query : query.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<T> ReadSingleOrDefaultAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<T> ReadFirstOrDefaultAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<T> ReadLastOrDefaultAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.LastOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<T> ReadFirstAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.FirstAsync(cancellationToken);
    }

    public virtual async Task<T> ReadLastAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.LastAsync(cancellationToken);
    }

    public virtual async Task<T> ReadSingleAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await query.SingleAsync(cancellationToken);
    }

    public virtual async Task<bool> ExistAsync(
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default) =>
        await _table.AnyAsync(filter, cancellationToken);

    #endregion

    #region Sync Reading

    public virtual IQueryable<T> Query(
        bool noTracking,
        Expression<Func<T, bool>> filter = null,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.AsQueryable();
       
        query = filter is not null ? query.Where(filter) : query;

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query;
    }

    public virtual IEnumerable<T> ReadAll(
        bool noTracking,
        Expression<Func<T, bool>> filter = null,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.AsQueryable();
        query = filter is not null ? query.Where(filter) : query;

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.ToList();
    }

    public virtual T ReadSingleOrDefault(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.SingleOrDefault();
    }

    public virtual T ReadFirstOrDefault(
        bool noTracking, 
        Expression<Func<T, bool>> filter, 
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.FirstOrDefault();
    }

    public virtual T ReadLastOrDefault(
        bool noTracking, 
        Expression<Func<T, bool>> filter, 
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.LastOrDefault();
    }

    public virtual T ReadFirst(
        bool noTracking, 
        Expression<Func<T, bool>> filter, 
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.First();
    }

    public virtual T ReadLast(
        bool noTracking, 
        Expression<Func<T, bool>> filter, 
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.Last();
    }

    public virtual T ReadSingle(
        bool noTracking, 
        Expression<Func<T, bool>> filter, 
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.Single();
    }

    public virtual bool Exist(Expression<Func<T, bool>> filter) => _table.Any(filter);

    public virtual async Task<IQueryable<T>> QueryFilterAsync(
        bool noTracking, 
        Expression<Func<T, bool>> filter, 
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _table.Where(filter);
        query = noTracking == true ? query.AsNoTracking() : query;
        return await Task.Run(() => query.AsQueryable(), cancellationToken);
    }

    public virtual async Task<IQueryable<T>> QueryFilterAndIncludeAsync(
        bool noTracking, 
        Expression<Func<T, bool>> filter,
        Expression<Func<T, object>>[] includeProperties, 
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _table.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await Task.Run(() => query.AsQueryable(), cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> ReadAllWithPaginationAsync(
        bool noTracking, 
        int pageSize = 10,
        int PageNumber = 1, 
        Expression<Func<T, bool>> filter = null, 
        CancellationToken cancellationToken = default, 
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table;

        query = query.Skip((PageNumber - 1) * pageSize)
         .Take(pageSize);

        query = filter is null ? query : query.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return await Task.Run(() => query.AsQueryable(), cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> ReadAllWithFilterAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _table.Where(filter);
        query = noTracking == true ? query.AsNoTracking() : query;
        return await Task.Run(() => query.AsQueryable(), cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> ReadAllWithFilterAndIncludeAsync(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        Expression<Func<T, object>>[] includeProperties,
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _table.Where(filter);

        foreach (var item in includeProperties)
        {
            query = query.Include(item);
        }

        query = noTracking == true ? query.AsNoTracking() : query;
        return await Task.Run(() => query.AsQueryable(), cancellationToken);
    }

    public virtual IQueryable<T> QueryFilter(
        bool noTracking,
        Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = _table.Where(filter);
        query = noTracking == true ? query.AsNoTracking() : query;
        return query;
    }

    public virtual IQueryable<T> QueryFilterAndInclude(
        bool noTracking,
        Expression<Func<T, bool>> filter,
        Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table;
        query = filter is null ? query : query.Where(filter);


        foreach (var item in includeProperties)
        {
            query = query.Include(item);
        }

        query = noTracking == true ? query.AsNoTracking() : query;
        return query;
    }

    public virtual IEnumerable<T> ReadAllWithPagination(
        bool noTracking,
        int pageSize = 10,
        int PageNumber = 1,
        Expression<Func<T, bool>> filter = null,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _table;

        query = query.Skip((PageNumber - 1) * pageSize)
         .Take(pageSize);

        query = filter is null ? query : query.Where(filter);

        if (includeProperties is not null)
        {
            foreach (var item in includeProperties)
            {
                query = query.Include(item);
            }
        }
        query = noTracking == true ? query.AsNoTracking() : query;
        return query.ToList();
    }


    #endregion
}
