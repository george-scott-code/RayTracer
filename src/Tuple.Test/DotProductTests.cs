using Xunit;
using TupleLibrary;

namespace TupleTests;

public class DotProductTests
{
    [Fact]
    public void DotProduct_of_two_tuples()
    {
        // Given
        Tuple t1 = Tuple.Vector(1, 2, 3);
        Tuple t2 = Tuple.Vector(2, 3, 4);
        // When
        var dotProduct = t1.Dot(t2);
        // Then
        Assert.Equal(20, dotProduct);
    }
}
