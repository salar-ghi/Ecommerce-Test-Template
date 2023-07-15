namespace Domain.Base;

public abstract class ValueObject<TId>
{
    public TId Id { get; protected set; } = default!;
    public DateTime Created { get; protected set; } = default!;
}


public abstract class ValueObject : ValueObject<long>
{

}
