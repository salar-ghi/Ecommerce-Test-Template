using System.ComponentModel;
using ErrorOr;


namespace Domain.ValueObjects.Products;

public record Name
{
    public Name() { }

    public string Value { get; private set; } = default!;

    public const int MinLength = 3;
    public const int MaxLength = 100;

    //public static Name Validate(string value)
    //{
    //    if (value.Length is < MinLength or > MaxLength)
    //        throw new ArgumentException($"The text must be at least {MinLength} " +
    //        $"characters long and most {MaxLength}");

    //    //if (!error.Any())
    //    return new Name { Value = value };
    //}

    public static Name Of(string value)
    {
        // validations should be placed here instead of constructor
        Guard.Against.NullOrEmpty(value);

        if (value.Length is < MinLength or > MaxLength)
            throw new ArgumentException($"The text must be at least {MinLength} " +
            $"characters long and most {MaxLength}");

        return new Name { Value = value };
    }

    public static implicit operator string(Name value) => value.Value;
}
