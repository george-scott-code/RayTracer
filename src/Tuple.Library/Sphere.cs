using System;

namespace TupleLibrary;

public class Sphere : IEquatable<Sphere>
{
    public Matrix Transform { get; set; }
    public Material Material { get; set; }

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

    public Intersection[] Intersection(Ray ray)
    {
         //transform before intersection
        var rayT = Transform.Inverse() * ray;

        // the vector from the sphere's center, to the ray origin
        // remember: the sphere is centered at the world origin
        var sphere_to_ray = rayT.Origin.Subtract(Tuple.Point(0, 0, 0));
        var a = rayT.Direction.Dot(rayT.Direction);
        var b = 2 * rayT.Direction.Dot( sphere_to_ray);
        var c = sphere_to_ray.Dot( sphere_to_ray) - 1;

        var discriminant = CalculateDiscriminant(a, b, c);
        if(discriminant < 0)
        {
            return new Intersection[0];
        }

        double t1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
        double t2 = (-b + Math.Sqrt(discriminant)) / (2 * a);

        return new Intersection[2]
        {
            new Intersection(t1, this), 
            new Intersection(t2, this)
        };
    }

    private double CalculateDiscriminant(double a, double b, double c)
    {
        var discriminant = (b*b) - 4 * a * c;
        return discriminant;
    }

    public TupleLibrary.Tuple NormalAt(Tuple point)
    {
        var object_point = this.Transform.Inverse() * point;
        var object_normal = object_point.Subtract(Tuple.Point(0, 0, 0));
        var world_normal = this.Transform.Inverse().Transpose() * object_normal;

        //alternatively use the 3*3 submatrix of the transform so w is not affected
        world_normal.W = 0;
        return world_normal.Normalize();
    }

    public bool Equals(Sphere other)
    {
        if (other is null)
        {
            return false;
        }

        if (Object.ReferenceEquals(this, other))
        {
            return true;
        }

        if (this.GetType() != other.GetType())
        {
            return false;
        }
        return (Material.Equals(other.Material) && Transform.Equals(other.Transform));
    }

    public override int GetHashCode()
    {
       return HashCode.Combine(Material.GetHashCode(), Transform.GetHashCode());
    }
}