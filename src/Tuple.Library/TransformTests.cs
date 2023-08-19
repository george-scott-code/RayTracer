using System.Numerics;
using Xunit;

namespace TupleLibrary;

public class TransformTests
{
    // Scenario: The transformation matrix for the default orientation
    // Given from ← point(0, 0, 0)
    // And to ← point(0, 0, -1)
    // And up ← vector(0, 1, 0)
    // When t ← view_transform(from, to, up)
    // Then t = identity_matrix
    [Fact]
    public void Transform_matrix_default_orientation()
    {
        var from = Tuple.Point(0, 0, 0);
        var to = Tuple.Point(0, 0, -1);
        var up = Tuple.Vector(0, 1, 0);

        var t = Matrix.ViewTransform(from, to, up);
        
        Assert.Equivalent(Matrix.Identity(), t);
    }

    // Scenario: A view transformation matrix looking in positive z direction
    // Given from ← point(0, 0, 0)
    // And to ← point(0, 0, 1)
    // And up ← vector(0, 1, 0)
    // When t ← view_transform(from, to, up)
    // Then t = scaling(-1, 1, -1)
    [Fact]
    public void Transform_matrix_looking_in_positive_z_direction()
    {
        var from = Tuple.Point(0, 0, 0);
        var to = Tuple.Point(0, 0, 1);
        var up = Tuple.Vector(0, 1, 0);

        var t = Matrix.ViewTransform(from, to, up);
        
        Assert.Equivalent(Matrix.Scaling(-1, 1, -1), t);
    }

    // Scenario: The view transformation moves the world
    // Given from ← point(0, 0, 8)
    // And to ← point(0, 0, 0)
    // And up ← vector(0, 1, 0)
    // When t ← view_transform(from, to, up)
    // Then t = translation(0, 0, -8)
    [Fact]
    public void Transform_matrix_moves_world()
    {
        var from = Tuple.Point(0, 0, 8);
        var to = Tuple.Point(0, 0, 0);
        var up = Tuple.Vector(0, 1, 0);

        var t = Matrix.ViewTransform(from, to, up);
        
        Assert.Equivalent(Matrix.Translation(0, 0, -8), t);
    }

    // Scenario: An arbitrary view transformation
    // Given from ← point(1, 3, 2)
    // And to ← point(4, -2, 8)
    // And up ← vector(1, 1, 0)
    // When t ← view_transform(from, to, up)
    // Then t is the following 4x4 matrix:
    //      | -0.50709 | 0.50709 | 0.67612 | -2.36643 |
    //      | 0.76772 | 0.60609 | 0.12122 | -2.82843 |
    //      | -0.35857 | 0.59761 | -0.71714 | 0.00000 |
    //      | 0.00000 | 0.00000 | 0.00000 | 1.00000 |
    [Fact]
    public void Arbitrary_view_transformation()
    {
        var from = Tuple.Point(1, 3, 2);
        var to = Tuple.Point(4, -2, 8);
        var up = Tuple.Vector(1, 1, 0);

        var t = Matrix.ViewTransform(from, to, up);
        
        double[,] elements = new double[4,4]
        {
            {-0.50709 , 0.50709 ,  0.67612 , -2.36643 },
            { 0.76772 , 0.60609 ,  0.12122 , -2.82843 },
            {-0.35857 , 0.59761 , -0.71714,   0.00000 },
            { 0.00000 , 0.00000 ,  0.00000 ,  1.00000 },
        };
        var expected = new Matrix(elements);

        Assert.True(expected.Equals(t));
    }
}