using TupleLibrary.Extensions;

namespace TupleLibrary;

public class Plane : Shape
{
    public override Intersection[] IntersectTransformed(Ray ray)
    {
        // if ray is parallel
        if (ray.Direction.Y.DZero())
            return new Intersection[]{};

        return new Intersection[]{};
    }

    public override TupleLibrary.Tuple NormalAtTransformed(TupleLibrary.Tuple point)
    {
        return TupleLibrary.Tuple.Vector(0, 1, 0);
    }
}