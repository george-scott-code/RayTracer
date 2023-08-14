using System.Collections.Generic;
using System.Linq;

namespace TupleLibrary;

public class World
{
    public PointLight Light { get; set; }
    public List<Sphere> Objects { get; set; } = new List<Sphere>();

    public World()
    {
        
    }

    public static World GetDefaultWorld()
    {
        var world = new World
        {
            Light = new PointLight(Tuple.Point(-10, 10, -10), new Color(1, 1, 1))
        };

        Material m1 = new(new Color(0.8, 1.0, 0.6), 0.1, 0.7, 0.2, 200.00);

        var transform = Matrix.Scaling(0.5, 0.5, 0.5);

        world.Objects.Add(new Sphere(m1));
        world.Objects.Add(new Sphere(transform));

        return world;
    }

    internal Intersection[] Intersect(Ray ray)
    {
        var intersections = new List<Intersection>();
        foreach(Sphere obj in Objects)
        {
            intersections.AddRange(obj.Intersection(ray));
        }
        return intersections.OrderBy(x => x.T).ToArray();
    }

    internal Color ShadeHit(IntersectComputations comps)
    {
        // TODO: Suport Multiple Light Sources
        // You would need to make sure your shade_hit()
        // function iterates over all of the light sources, calling lighting() for each one and adding
        // the colors together.
        return Lighting.GetLighting(
            comps.Obj.Material, 
            this.Light,
            comps.Point, 
            comps.EyeV, 
            comps.NormalV);
    }

    internal Color ColorAt(Ray ray)
    {
        var intersections = this.Intersect(ray);
        var hit = intersections.Hit();
        
        if(hit == null)
        {
            return new Color(0, 0, 0);
        }
        return ShadeHit(hit.PrepareComputations(ray));
    }
}