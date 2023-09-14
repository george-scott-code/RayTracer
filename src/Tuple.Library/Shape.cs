namespace TupleLibrary;

public abstract class Shape
{
    public Matrix Transform { get; set; }
    public Material Material { get; set; }

    public Shape()
    {
        Transform = Matrix.Identity();
        Material = new Material();
    }

    public Intersection[] Intersection(Ray ray)
    {
        var rayT = Transform.Inverse() * ray;
        return IntersectTransformed(rayT);
    }

    public abstract Intersection[] IntersectTransformed(Ray ray);
}