using System;

namespace TupleLibrary;

public class Sphere
{
    public Sphere()
    {
    }

    public double[] Intersection(Ray ray)
    {
        // the vector from the sphere's center, to the ray origin
        // remember: the sphere is centered at the world origin
        var sphere_to_ray = ray.Origin.Subtract(Tuple.Point(0, 0, 0));
        var a = ray.Direction.Dot(ray.Direction);
        var b = 2 * ray.Direction.Dot( sphere_to_ray);
        var c = sphere_to_ray.Dot( sphere_to_ray) - 1;

        var discriminant = CalculateDiscriminant(a, b, c);
        if(discriminant < 0)
        {
            return new double[0];
        }

        double t1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
        double t2 = (-b + Math.Sqrt(discriminant)) / (2 * a);

        return new double[2]
        {
            t1, t2
        };
    }

    private double CalculateDiscriminant(double a, double b, double c)
    {
        var discriminant = (b*b) - 4 * a * c;
        return discriminant;
    }
}