﻿namespace Domain.ValueObjects.Products;

public record Dimensions
{
    public Dimensions() { }


    public int Height { get; private set; }
    public int Width { get; private set; }
    public int Depth { get; private set; }

    public static Dimensions Of(int height, int width, int depth)
    {
        Guard.Against.NegativeOrZero(height);
        Guard.Against.NegativeOrZero(width);
        Guard.Against.NegativeOrZero(depth);

        return new Dimensions
        {
            Height = height,
            Width = width,
            Depth = depth,
        };
    }

    public override string ToString()
    {
        return FormattedDescription();
    }

    private string FormattedDescription()
    {
        return $"HxWxD: {Height} x {Width} x {Depth}";
    }

}
