using System.Linq.Expressions;

namespace Clean.Domain.Contracts.Interfaces;

public interface IEFRepository<TEntity, TId>:IUnitOfWork
where TEntity : class, IEntity<TId>
{
    void Insert(TEntity entity);
    Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken);

    void Update(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    void Delete(TEntity entity);
    Task<TEntity?> DeleteAsync(TEntity entity, CancellationToken cancellationToken);

    IQueryable<TEntity> GetQueryable();

    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellation, Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);

    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> GetAsync(CancellationToken cancellation, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    int Save();

    //TODO: Pagination ile ilgili metot eklenecek
}
