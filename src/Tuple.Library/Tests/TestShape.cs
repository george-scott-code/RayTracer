using System;
namespace TupleLibrary.Tests;
public class TestShape : Shape
{
    public Ray TransformedRay { get; private set; }

    public override Intersection[] IntersectTransformed(Ray ray)
    {
        TransformedRay = ray;
        return null;
    }

    public override TupleLibrary.Tuple NormalAtTransformed(TupleLibrary.Tuple objectPoint)
    {
        return TupleLibrary.Tuple.Vector(objectPoint.X, objectPoint.Y, objectPoint.Z);
    }
}