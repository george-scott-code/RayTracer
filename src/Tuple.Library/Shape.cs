namespace TupleLibrary;

public class Shape
{
    public Matrix Transform { get; set; }
    public Material Material { get; set; }

    public Ray TransformedRay { get; internal set; }

    public Shape()
    {
        Transform = Matrix.Identity();
        Material = new Material();
    }

    public Intersection[] Intersection(Ray ray)
    {
         //transform before intersection
        TransformedRay = Transform.Inverse() * ray;
        // call subclass
        return new Intersection[]{};
    }
}