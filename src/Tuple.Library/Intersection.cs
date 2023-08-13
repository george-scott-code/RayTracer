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
        var comp = new IntersectComputations(this.T, this.Obj);
        comp.Point = ray.Position(comp.T);
        comp.EyeV = -ray.Direction;
        comp.NormalV = comp.Obj.NormalAt(comp.Point);
        return comp;
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