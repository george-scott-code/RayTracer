using System;
using System.Linq;
using Xunit;

namespace TupleLibrary;

public class ShapeTests
{
    // Scenario: The default transformation
    // Given s ← test_shape()
    // Then s.transform = identity_matrix
    [Fact]
    public void DefaultTransformation()
    {
        var shape = new TestShape();
        Assert.Equal(Matrix.Identity(), shape.Transform);
    }

    // Scenario: Assigning a transformation
    // Given s ← test_shape()
    // When set_transform(s, translation(2, 3, 4))
    // Then s.transform = translation(2, 3, 4)
    [Fact]
    public void AssignedTransformation()
    {
        var shape = new TestShape();
        shape.Transform = Matrix.Translation(2, 3, 4);
        Assert.Equal(Matrix.Translation(2, 3, 4), shape.Transform);
    }

    // Scenario: The default material
    // Given s ← test_shape()
    // When m ← s.material
    // Then m = material()
    [Fact]
    public void DefaultMaterial()
    {
        var shape = new TestShape();
        Assert.Equal(new Material(), shape.Material);
    }

    // Scenario: Assigning a material
    // Given s ← test_shape()
    // And m ← material()
    // And m.ambient ← 1
    // When s.material ← m
    // Then s.material = m
    [Fact]
    public void AssignedMaterial()
    {
        var shape = new TestShape();
        Material m = new Material() { Ambient = 1 };
        shape.Material = m;
        Assert.Equal(m, shape.Material);
    }

    // Scenario: Intersecting a scaled shape with a ray
    // Given r ← ray(point(0, 0, -5), vector(0, 0, 1))
    // And s ← test_shape()
    // When set_transform(s, scaling(2, 2, 2))
    // And xs ← intersect(s, r)
    // Then s.saved_ray.origin = point(0, 0, -2.5)
    // And s.saved_ray.direction = vector(0, 0, 0.5)
    [Fact]
    public void IntersectScaledShapeWithARay()
    {
        var ray = new Ray(TupleLibrary.Tuple.Point(0, 0, -5), TupleLibrary.Tuple.Vector(0, 0, 1));
        var shape = new TestShape();
        shape.Transform = Matrix.Scaling(2, 2, 2);
        var xs = shape.Intersection(ray);
        Assert.Equal(TupleLibrary.Tuple.Point(0, 0, -2.5), shape.TransformedRay.Origin);
        Assert.Equal(TupleLibrary.Tuple.Vector(0, 0, 0.5), shape.TransformedRay.Direction);
    }

    // Scenario: Intersecting a translated shape with a ray
    // Given r ← ray(point(0, 0, -5), vector(0, 0, 1))
    // And s ← test_shape()
    // When set_transform(s, translation(5, 0, 0))
    // And xs ← intersect(s, r)
    // Then s.saved_ray.origin = point(-5, 0, -5)
    // And s.saved_ray.direction = vector(0, 0, 1)
    [Fact]
    public void IntersectTranslatedShapeWithARay()
    {
        var ray = new Ray(TupleLibrary.Tuple.Point(0, 0, -5), TupleLibrary.Tuple.Vector(0, 0, 1));
        var shape = new TestShape();
        shape.Transform = Matrix.Translation(5, 0, 0);
        var xs = shape.Intersection(ray);
        Assert.Equal(TupleLibrary.Tuple.Point(-5, 0, -5), shape.TransformedRay.Origin);
        Assert.Equal(TupleLibrary.Tuple.Vector(0, 0, 1), shape.TransformedRay.Direction);
    }

    // Scenario: Computing the normal on a translated shape
    // Given s ← test_shape()
    // When set_transform(s, translation(0, 1, 0))
    // And n ← normal_at(s, point(0, 1.70711, -0.70711))
    // Then n = vector(0, 0.70711, -0.70711)
    [Fact]
    public void ComputingNormalOnTranslatedShape()
    {
        var shape = new TestShape();
        shape.Transform = Matrix.Translation(0, 1, 0);
        var n = shape.NormalAt(TupleLibrary.Tuple.Point(0, 1.70711, -0.70711));
        Assert.Equal(TupleLibrary.Tuple.Vector(0, 0.70711, -0.70711), n);
    }

    // Scenario: Computing the normal on a transformed shape
    // Given s ← test_shape()
    // And m ← scaling(1, 0.5, 1) * rotation_z(π/5)
    // When set_transform(s, m)
    // And n ← normal_at(s, point(0, √2/2, -√2/2))
    // Then n = vector(0, 0.97014, -0.24254)
    [Fact]
    public void ComputingNormalOnTransformedShape()
    {
        var shape = new TestShape();
        var m = Matrix.Scaling(1, 0.5, 1) * Matrix.RotationZ(Math.PI / 5);
        shape.Transform = m;
        var n = shape.NormalAt(TupleLibrary.Tuple.Point(0, 0.70710678118, -0.70710678118));
        Assert.Equal(TupleLibrary.Tuple.Vector(0, 0.97014, -0.24254), n);
    }
}
