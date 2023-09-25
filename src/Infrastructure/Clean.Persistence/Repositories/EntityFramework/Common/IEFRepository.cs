namespace Clean.Persistence.Repositories.EntityFramework.Common;

public interface IEFRepository<TEntity, TKey>
where TEntity : Entity<TKey>, new()
{
    void Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);

    IQueryable<TEntity> GetQueryable();

    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellation, Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> GetAsync(CancellationToken cancellation, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);


    //TODO: Pagination ile ilgili metot eklenecek
}
