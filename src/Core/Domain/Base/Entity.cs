namespace Domain.Base;

public abstract class Entity<TKey>
{
    public TKey Id { get; protected set; } = default!;
    public bool IsRemoved { get; protected set; } = default(bool);
    public bool IsActive { get; protected set; } = default(bool);

    public DateTime Created { get; protected set; } = default!;
    //public Guid CreaedBy { get; private set; } = default!;
    
    public DateTime Modified { get; private set; } = default!;


}


public abstract class Entity: Entity<long>
{
}


//public abstract class Entity<TKey> : IEquatable<Entity<TKey>>
//{
//    protected Entity(TKey id) => Id = id;
//    protected Entity() { }


//    public TKey Id { get; protected init; } = default!;
//    public DateTime CreateDateTime { get; protected init; }
//    public DateTime ModifiedDateTime { get; protected init; }


//    public override bool Equals(object? obj)
//    {
//        if (obj is null)
//        {
//            return false;
//        }
//        if (obj.GetType() != GetType())
//        {
//            return false;
//        }
//        if (obj is not Entity<TKey> entity)
//        {
//            return false;
//        }
//        return entity.Id == Id;
//    }

//    public override int GetHashCode()
//    {
//        return Id.GetHashCode() * 41;
//    }

//    public bool Equals(Entity<TKey>? other)
//    {
//        if (other is null)
//        {
//            return false;
//        }
//        if (other.GetType() != GetType())
//        {
//            return false;
//        }
//        return other.Id == Id;
//    }


//    public static bool operator ==(Entity<TKey>? first, Entity<TKey>? second)
//    {
//        return first is not null && second is not null && first.Equals(second);
//    }

//    public static bool operator !=(Entity<TKey>? first, Entity<TKey>? second)
//    {
//        return !(first == second);
//    }

//}