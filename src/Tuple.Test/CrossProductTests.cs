using Xunit;
using TupleLibrary;

namespace TupleTests;

public class CrossProductTests
{
    [Fact]
    public void Cross_product_of_two_vectors()
    {
        // Given
        Tuple t1 = Tuple.Vector(1, 2, 3);
        Tuple t2 = Tuple.Vector(2, 3, 4);

        // When
        Tuple t3 = t1.Cross(t2);
        Tuple expected = Tuple.Vector(-1,2,-1);
        // Then
        Assert.Equal(expected, t3); 
    }

    [Fact]
    public void Cross_product_of_two_vectors_opposite_order()
    {
        // Given
        Tuple t1 = Tuple.Vector(1, 2, 3);
        Tuple t2 = Tuple.Vector(2, 3, 4);

        // When
        Tuple t3 = t2.Cross(t1);
        Tuple expected = Tuple.Vector(1, -2, 1);
        // Then
        Assert.Equal(expected, t3); 
    }
}
