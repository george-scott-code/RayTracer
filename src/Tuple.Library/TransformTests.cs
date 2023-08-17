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

        var t =Matrix.ViewTransform(from, to, up);
        
        Assert.Equivalent(Matrix.Identity(), t);
    }
}