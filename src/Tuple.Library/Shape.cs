using System;
using System.IO.Compression;
using System.Linq;
using TupleLibrary.Extensions;
using Xunit;

namespace TupleLibrary;

public class Shape
{
    public Matrix Transform { get; set; }
    public Material Material { get; set; }

    public Shape()
    {
        Transform = Matrix.Identity();
        Material = new Material();
    }
}

public class ShapeTests
{
    // Scenario: The default transformation
    // Given s ← test_shape()
    // Then s.transform = identity_matrix
    [Fact]
    public void DefaultTransformation()
    {
        var shape = new Shape();
        Assert.Equal(Matrix.Identity(), shape.Transform);
    }

    // Scenario: Assigning a transformation
    // Given s ← test_shape()
    // When set_transform(s, translation(2, 3, 4))
    // Then s.transform = translation(2, 3, 4)
    [Fact]
    public void AssignedTransformation()
    {
        var shape = new Shape();
        shape.Transform = Matrix.Translation(2, 3, 4);
        Assert.Equal(Matrix.Translation(2, 3, 4), shape.Transform);
    }
}
