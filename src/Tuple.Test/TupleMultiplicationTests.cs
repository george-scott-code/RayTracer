using Xunit;
using TupleLibrary;

namespace TupleTests;

public class TupleMultiplicationTests
{
    [Fact]
    public void Multiplying_a_tuple_by_a_scaler()
    {
        Tuple t1 = new Tuple(1, -2, 3, -4);

        var result = t1 * 3.5;

        var expected = new Tuple(3.5, -7, 10.5, -14);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Multiplying_a_tuple_by_a_fraction()
    {
        Tuple t1 = new Tuple(1, -2, 3, -4);

        var result = t1 * 0.5;

        var expected = new Tuple(0.5, -1, 1.5, -2);
        Assert.Equal(expected, result);
    }
}