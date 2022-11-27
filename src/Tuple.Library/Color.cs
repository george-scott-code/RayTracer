using System;

namespace TupleLibrary;

public class Color : Tuple
{
    public Color(double red, double green, double blue) 
        : base(red, green, blue, 0)
    {
    }

    public double Red => this.X;
    public double Green => this.Y;
    public double Blue => this.Z;

    public static Color operator +(Color c1, Color c2) => 
        new Color(c1.X + c2.X, c1.Y + c2.Y, c1.Z + c2.Z);

    public static Color operator -(Color c1, Color c2) => 
        new Color(c1.X - c2.X, c1.Y - c2.Y, c1.Z - c2.Z);

    public static Color operator *(Color c1, Color c2) => 
        new Color(c1.X * c2.X, c1.Y * c2.Y, c1.Z * c2.Z);
}
