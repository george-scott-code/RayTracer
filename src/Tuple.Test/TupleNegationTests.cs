using Xunit;
using TupleLibrary;

namespace TupleTests;

public class TupleNegationTests
{
    [Fact]
    public void Subtracting_a_Vector_from_a_zero_vector()
    {
        Tuple t1 = Tuple.Vector(0, 0, 0);
        Tuple t2 = Tuple.Vector(1, -2, 3);

        var result = t1.Subtract(t2);

        var expected = new Tuple(-1, 2, -3, 0);
        Assert.Equal(expected, result);
        Assert.False(result.IsPoint);
        Assert.True(result.IsVector);
    }

    [Fact]
    public void TupleNegation_using_operator_overloading()
    {
        Tuple t1 = Tuple.Vector(1, -2, 3);

        var result = -t1;

        var expected = new Tuple(-1, 2, -3, 0);
        Assert.Equal(expected, result);
        Assert.False(result.IsPoint);
        Assert.True(result.IsVector);
    }
}