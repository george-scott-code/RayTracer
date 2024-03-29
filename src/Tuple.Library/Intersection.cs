using TupleLibrary.Extensions;
using TupleLibrary.Shapes;

namespace TupleLibrary;

public class Intersection
{
    public Intersection(double t, Shape obj)
    {
        T = t;
        Obj = obj;
    }

    public double T { get; private set; }
    public Shape Obj { get; private set; }

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
        comps.OverPoint = comps.Point.Add(comps.NormalV * DoubleExtensions.EPSILON);
        return comps;
    }
}