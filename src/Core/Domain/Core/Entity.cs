namespace Domain.Base;

public abstract class Entity<TKey> : IAggregateRoot
{
    public TKey Id { get; protected set; } = default!;
    public bool IsRemoved { get; protected set; } = default(bool);

    
}


public abstract class Entity: Entity<long>
{
}