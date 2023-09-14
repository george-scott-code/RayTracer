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
}