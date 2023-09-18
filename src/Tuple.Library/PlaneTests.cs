using System;
using System.Linq;
using Xunit;

namespace TupleLibrary;

public class PlaneTests
{
    // Scenario: The normal of a plane is constant everywhere
    // Given p ← plane()
    // When n1 ← local_normal_at(p, point(0, 0, 0))
    // And n2 ← local_normal_at(p, point(10, 0, -10))
    // And n3 ← local_normal_at(p, point(-5, 0, 150))
    // Then n1 = vector(0, 1, 0)
    // And n2 = vector(0, 1, 0)
    // And n3 = vector(0, 1, 0)
    [Fact]
    public void ComputingNormalOnAPlane_IsConstant()
    {
        var plane = new Plane();
        var n1 = plane.NormalAtTransformed(TupleLibrary.Tuple.Point(0, 0, 0));
        var n2 = plane.NormalAtTransformed(TupleLibrary.Tuple.Point(10, 0, -10));
        var n3 = plane.NormalAtTransformed(TupleLibrary.Tuple.Point(-5, 0, 150));

        Assert.Equal(TupleLibrary.Tuple.Vector(0, 1, 0), n1);
        Assert.Equal(TupleLibrary.Tuple.Vector(0, 1, 0), n2);
        Assert.Equal(TupleLibrary.Tuple.Vector(0, 1, 0), n3);
    }

    // Scenario: Intersect with a ray parallel to the plane
    // Given p ← plane()
    // And r ← ray(point(0, 10, 0), vector(0, 0, 1))
    // When xs ← local_intersect(p, r)
    // Then xs is empty
    [Fact]
    public void IntersectPlaneWithParallelRay()
    {
        var plane = new Plane();
        var ray = new Ray(TupleLibrary.Tuple.Point(0, 10, 0), TupleLibrary.Tuple.Vector(0, 0, 1));
        var xs = plane.IntersectTransformed(ray);
        Assert.Empty(xs);
    }

    // Scenario: Intersect with a coplanar ray
    // Given p ← plane()
    // And r ← ray(point(0, 0, 0), vector(0, 0, 1))
    // When xs ← local_intersect(p, r)
    // Then xs is empty
    [Fact]
    public void IntersectPlaneWithCoplanarlRay()
    {
        var plane = new Plane();
        var ray = new Ray(TupleLibrary.Tuple.Point(0, 0, 0), TupleLibrary.Tuple.Vector(0, 0, 1));
        var xs = plane.IntersectTransformed(ray);
        Assert.Empty(xs);
    }
}