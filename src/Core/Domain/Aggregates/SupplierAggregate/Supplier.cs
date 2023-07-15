namespace Domain.Aggregates.SupplierAggregate;

public class Supplier : AggregateRoot<int>
{
    public SupplierType SupplierType { get; protected set; }
    public string Name { get; protected set; } = default!;
    public string Description { get; protected set; } = default!;
    public string Phone { get; protected set; } = default!;
    public string LogoUri { get; protected set; } = default!;
}