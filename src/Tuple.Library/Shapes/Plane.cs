using TupleLibrary.Extensions;

namespace TupleLibrary.Shapes;

public class Plane : Shape
{
    public override Intersection[] IntersectTransformed(Ray ray)
    {
        // if ray is parallel there is no intersection
        if (ray.Direction.Y.DZero())
            return new Intersection[]{};

        var t = -ray.Origin.Y / ray.Direction.Y;
        return new Intersection[]{ new(t, this)};
    }

    public override TupleLibrary.Tuple NormalAtTransformed(TupleLibrary.Tuple point)
    {
        return TupleLibrary.Tuple.Vector(0, 1, 0);
    }
}