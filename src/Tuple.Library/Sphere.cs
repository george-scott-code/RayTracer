using System;

namespace TupleLibrary;

public class Sphere
{
    public Sphere()
    {
    }

    public double[] Intersection(Ray ray)
    {
        var discriminant = CalculateDiscriminant(ray);
        if(discriminant < 0)
        {
            return new double[0];
        }
        return new double[2];
    }

    private double CalculateDiscriminant(Ray ray)
    {
        // the vector from the sphere's center, to the ray origin
        // remember: the sphere is centered at the world origin
        var sphere_to_ray = ray.Origin.Subtract(Tuple.Point(0, 0, 0));
        var a = ray.Direction.Dot(ray.Direction);
        var b = 2 * ray.Direction.Dot( sphere_to_ray);
        var c = sphere_to_ray.Dot( sphere_to_ray) - 1;
        var discriminant = (b*b) - 4 * a * c;
        return discriminant;
    }
}