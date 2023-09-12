namespace TupleLibrary;

public class Shape
{
    public Matrix Transform { get; set; }
    public Material Material { get; set; }

    public Shape()
    {
        Transform = Matrix.Identity();
        Material = new Material();
    }
}