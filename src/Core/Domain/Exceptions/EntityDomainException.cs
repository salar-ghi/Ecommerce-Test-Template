namespace Domain.Exceptions;

internal class EntityDomainException : DomainException
{

    public EntityDomainException(string message)
        : base(message) { }

    //public EntityDomainException(string name, object key)
    //    : base($"Entity \"{name}\" ({key}) was not found") { }

    //public EntityDomainException(long id)
    //    : base($"Category with id: '{id}' not found.") { }

}
