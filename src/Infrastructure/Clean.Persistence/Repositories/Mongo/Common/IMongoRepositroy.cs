namespace Clean.Persistence.Repositories.Mongo.Common;

public interface IMongoRepositroy<TEntity>
where TEntity : MongoEntity, new()
{
   void Delete(string id, CancellationToken cancellationToken);
   Task DeleteAsync(string id, CancellationToken cancellationToken);
   void Insert(TEntity entity, CancellationToken cancellationToken);
   Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
   void Update(TEntity entity, CancellationToken cancellationToken);
   Task  UpdateAsync(TEntity entity, CancellationToken cancellationToken);

   Task<IEnumerable<TEntity>>GetAllAsync(CancellationToken cancellationToken, Expression<Func<TEntity,bool>>filter = null);
   Task<TEntity>GetAsync(Expression<Func<TEntity,bool>>filter, CancellationToken cancellationToken);
   Task<TEntity>GetByIdAsync(string id,CancellationToken cancellationToken);
}