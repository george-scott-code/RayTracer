using Xunit;
using TupleLibrary;

namespace TupleTests;

public class TupleAdditionTests
{
    [Fact]
    public void Point_AddVector_EqualsPoint()
    {
        Tuple t1 = Tuple.Point(1, 2, 3);
        Tuple t2 = Tuple.Vector(1, 2, 3);

        var result = t1.Add(t2);

        var expected = new Tuple(2, 4, 6, 1);
        Assert.Equal(expected, result);
        Assert.True(result.IsPoint);
    }

    [Fact]
    public void Vector_AddVector_EqualsVector()
    {
        Tuple t1 = Tuple.Vector(1, 2, 3);
        Tuple t2 = Tuple.Vector(1, 2, 3);

        var result = t1.Add(t2);

        var expected = new Tuple(2,4, 6, 0);
        Assert.Equal(expected, result);
        Assert.True(result.IsVector);
    }
    
    // TODO: should we handle this?
    [Fact]
    public void Point_AddPoint_EqualsSomething()
    {
        Tuple t1 = Tuple.Point(1, 2, 3);
        Tuple t2 = Tuple.Point(1, 2, 3);

        var result = t1.Add(t2);

        var expected = new Tuple(2, 4, 6, 2);
        Assert.Equal(expected, result);
        Assert.False(result.IsPoint);
        Assert.False(result.IsVector);
    }
}
