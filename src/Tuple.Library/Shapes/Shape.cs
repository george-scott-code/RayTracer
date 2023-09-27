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

    public TupleLibrary.Tuple NormalAt(Tuple point)
    {
        var object_point = this.Transform.Inverse() * point;
        var object_normal = NormalAtTransformed(object_point);
        var world_normal = this.Transform.Inverse().Transpose() * object_normal;

        //alternatively use the 3*3 submatrix of the transform so w is not affected
        world_normal.W = 0;
        return world_normal.Normalize();
    }

    public abstract Intersection[] IntersectTransformed(Ray ray);
    public abstract TupleLibrary.Tuple NormalAtTransformed(TupleLibrary.Tuple point);
}