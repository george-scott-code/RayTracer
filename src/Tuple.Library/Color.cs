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

    public static Color operator *(Color c1, double scalar) => 
        new Color(c1.X * scalar, c1.Y * scalar, c1.Z * scalar);

    public string[] ToRGB()
    {
        return new string[] {
            Normalize(Red).ToString(),
            Normalize(Green).ToString(),
            Normalize(Blue).ToString(),
        };
    }

    private int Normalize(double comp)
    {
        if (comp < 0) comp = 0;
        if (comp > 1) comp = 1;
        
        return (int)Math.Round(255*comp);
    }
}
