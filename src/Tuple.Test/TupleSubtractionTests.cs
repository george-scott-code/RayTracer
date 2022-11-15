using TupleLibrary;
using Xunit;

namespace TupleTests;

public class TupleSubtractionTests
{
    [Fact]
    public void SubrtractingTwoPoints()
    {
        Tuple t1 = Tuple.Point(3, 2, 7);
        Tuple t2 = Tuple.Point(5, 6, 1);

        var result = t1.Subtract(t2);

        var expected = new Tuple(-2, -4, 6, 0);
        Assert.Equal(expected, result);
        Assert.False(result.IsPoint);
        Assert.True(result.IsVector);
    }

    [Fact]
    public void SubrtractingVectorFromPoint()
    {
        Tuple t1 = Tuple.Point(3, 2, 7);
        Tuple t2 = Tuple.Vector(5, 6, 1);

        var result = t1.Subtract(t2);

        var expected = new Tuple(-2, -4, 6, 1);
        Assert.Equal(expected, result);
        Assert.True(result.IsPoint);
        Assert.False(result.IsVector);
    }

    [Fact]
    public void SubrtractingTwoVectors()
    {
        Tuple t1 = Tuple.Vector(3, 2, 7);
        Tuple t2 = Tuple.Vector(5, 6, 1);

        var result = t1.Subtract(t2);

        var expected = new Tuple(-2, -4, 6, 0);
        Assert.Equal(expected, result);
        Assert.False(result.IsPoint);
        Assert.True(result.IsVector);
    }

    // TODO: should we handle this?
    [Fact]
    public void SubrtractingPointFromVector()
    {
        Tuple t1 = Tuple.Vector(3, 2, 7);
        Tuple t2 = Tuple.Point(5, 6, 1);

        var result = t1.Subtract(t2);

        var expected = new Tuple(-2, -4, 6, -1);
        Assert.Equal(expected, result);
        Assert.False(result.IsPoint);
        Assert.False(result.IsVector);
    }
}