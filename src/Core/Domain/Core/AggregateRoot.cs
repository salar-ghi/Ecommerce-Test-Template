namespace Domain.Base;

public abstract class AggregateRoot<TKey> : IAggregateRoot
{
    public TKey Id { get; protected set; } = default!;
    public bool IsRemoved { get; protected set; } = false;
    public ActivationStatus IsActive { get; protected set; } = ActivationStatus.Active;

    public DateTime Created { get; protected set; } = default(DateTime);
    public Guid CreatedBy { get; protected set; } = default!;

    public DateTime Modified { get; protected set; } = default(DateTime);
    public Guid ModifiedBy { get; protected set; } = default!;
}

public abstract class AggregateRoot : AggregateRoot<long>
{
}
