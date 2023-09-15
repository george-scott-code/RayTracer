using System;
namespace TupleLibrary;
public class TestShape : Shape
{
    public Ray TransformedRay { get; private set; }

    public override Intersection[] IntersectTransformed(Ray ray)
    {
        TransformedRay = ray;
        return null;
    }

    public override TupleLibrary.Tuple local_normal_at(TupleLibrary.Tuple objectPoint)
    {
        return TupleLibrary.Tuple.Vector(objectPoint.X, objectPoint.Y, objectPoint.Z);
    }
}