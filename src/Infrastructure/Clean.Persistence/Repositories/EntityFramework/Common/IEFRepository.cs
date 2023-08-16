namespace Clean.Persistence.Repositories;

public interface IEFRepository<TEntity, TKey> : IAsyncDisposable
where TEntity : Entity<TKey>, new()
{
    IMapper _mapper { get; }
    void Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void Save();
    Task SaveAsync();

    IQueryable<TEntity> GetQueryable();
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

}
