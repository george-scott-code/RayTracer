using System;

namespace TupleLibrary;

public class Sphere : Shape, IEquatable<Sphere>
{
    public Sphere()
    {
        Transform = Matrix.Identity();
        Material = new Material();
    }

    public Sphere(Material m1)
    {
        Transform = Matrix.Identity();
        Material = m1;
    }

    public Sphere(Matrix transform)
    {
        Transform = transform;
        Material = new Material();;
    }

    private double CalculateDiscriminant(double a, double b, double c)
    {
        var discriminant = (b*b) - 4 * a * c;
        return discriminant;
    }

    public override Intersection[] IntersectTransformed(Ray rayT)
    {
        // the vector from the sphere's center, to the ray origin
        // remember: the sphere is centered at the world origin
        var sphere_to_ray = rayT.Origin.Subtract(Tuple.Point(0, 0, 0));
        var a = rayT.Direction.Dot(rayT.Direction);
        var b = 2 * rayT.Direction.Dot( sphere_to_ray);
        var c = sphere_to_ray.Dot( sphere_to_ray) - 1;
        var discriminant = CalculateDiscriminant(a, b, c);

        if(discriminant < 0)
            return new Intersection[0];

        double t1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
        double t2 = (-b + Math.Sqrt(discriminant)) / (2 * a);
        return new Intersection[2]
        {
            new Intersection(t1, this), 
            new Intersection(t2, this)
        };
    }

    public override TupleLibrary.Tuple NormalAtTransformed(TupleLibrary.Tuple point)
    {
        return point.Subtract(Tuple.Point(0, 0, 0));
    }

    public bool Equals(Sphere other)
    {
        if (other is null)
            return false;

        if (Object.ReferenceEquals(this, other))
            return true;

        if (this.GetType() != other.GetType())
            return false;

        return (Material.Equals(other.Material) && Transform.Equals(other.Transform));
    }

    public override int GetHashCode() => HashCode.Combine(Material.GetHashCode(), Transform.GetHashCode());
}
