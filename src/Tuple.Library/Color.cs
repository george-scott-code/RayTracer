namespace TupleLibrary;

public class Color : Tuple
{
    public Color(double red, double green, double blue) : base(red, green, blue, 0)
    {
    }

    public double Red => this.X;
    public double Green => this.Y;
    public double Blue => this.Z;
}
