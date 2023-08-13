using System;
using System.ComponentModel.Design.Serialization;
using System.Linq;

namespace TupleLibrary;

public class Intersection
{
    public Intersection(double t, Sphere obj)
    {
        this.T = t;
        this.Obj = obj;
    }

    public double T { get; private set; }
    public Sphere Obj { get; private set; }

    internal IntersectComputations PrepareComputations(Ray ray)
    {
        var comps = new IntersectComputations(this.T, this.Obj);
        comps.Point = ray.Position(comps.T);
        comps.EyeV = -ray.Direction;
        comps.NormalV = comps.Obj.NormalAt(comps.Point);

        if (comps.NormalV.Dot(comps.EyeV) < 0)
        {
            // vectors are pointing in (roughly) opposite directions
            comps.Inside = true;
            comps.NormalV = -comps.NormalV;
        }

        return comps;
    }
}

public static class Intersections
{
    public static Intersection Hit(this Intersection[] intersections)
    {
        // TODO: refactor to list
        // TODO: maybe better to maintain the order on construction
        var list = intersections.ToList();
        return list.Where(x => x.T > 0).OrderBy(x => x.T).FirstOrDefault();
    }
}