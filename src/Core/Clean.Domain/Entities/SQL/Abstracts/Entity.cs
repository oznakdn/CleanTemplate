namespace Clean.Domain.Entities.SQL.Abstracts;

public class Entity<TKey> : IEntity<TKey>
{
    public virtual TKey Id { get; set; }
}
