namespace Clean.Domain.Entities.Abstracts;

public class Entity<TKey> : IEntity<TKey>
{
    public virtual TKey Id { get; set; }
}
