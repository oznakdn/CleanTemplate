using Clean.Persistence.Repositories;
using MongoDB.Bson;

namespace Clean.Persistence.Data.Mongo.Repositories.Abstracts;

public interface IMongoRepositroy<TEntity>
where TEntity : Entity<ObjectId>,new()
{
   IMapper Mapper {get;}
   void Delete(ObjectId id, CancellationToken cancellationToken);
   Task DeleteAsync(ObjectId id, CancellationToken cancellationToken);
   void Insert(TEntity entity, CancellationToken cancellationToken);
   Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
   void Update(TEntity entity, CancellationToken cancellationToken);
   Task  UpdateAsync(TEntity entity, CancellationToken cancellationToken);

   Task<IEnumerable<TEntity>>GetAllAsync(CancellationToken cancellationToken, Expression<Func<TEntity,bool>>filter = null);
   Task<TEntity>GetAsync(Expression<Func<TEntity,bool>>filter, CancellationToken cancellationToken);
   Task<TEntity>GetByIdAsync(ObjectId id,CancellationToken cancellationToken);
}