using Xunit;
using TupleLibrary;

namespace TupleTests;
public class TupleTests
{
    [Fact]
    public void Tuple_WithW1_IsPoint()
    {
        Tuple tuple = new Tuple(4.3, -4.2, 3.1, 1.0);

        Assert.Equal(4.3, tuple.X);
        Assert.Equal(-4.2, tuple.Y);
        Assert.Equal(3.1, tuple.Z);
        Assert.Equal(1.0, tuple.W);
        Assert.True(tuple.IsPoint);
        Assert.False(tuple.IsVector);
    }

    [Fact]
    public void Tuple_WithW0_IsVector()
    {
        Tuple tuple = new Tuple(4.3, -4.2, 3.1,  0.0);

        Assert.Equal(4.3, tuple.X);
        Assert.Equal(-4.2, tuple.Y);
        Assert.Equal(3.1, tuple.Z);
        Assert.Equal(0.0, tuple.W);
        Assert.False(tuple.IsPoint);
        Assert.True(tuple.IsVector);
    }

    [Fact]
    public void Tuple_WithPointConstructor_IsPoint()
    {
        Tuple tuple = Tuple.Point(4.3, -4.2, 3.1);
        
        Assert.Equal(4.3, tuple.X);
        Assert.Equal(-4.2, tuple.Y);
        Assert.Equal(3.1, tuple.Z);
        Assert.Equal(1.0, tuple.W);
        Assert.True(tuple.IsPoint);
        Assert.False(tuple.IsVector);
    }

    [Fact]
    public void Tuple_WithPointConstructor_IsVector()
    {
        Tuple tuple = Tuple.Vector(4.3, -4.2, 3.1);
        
        Assert.Equal(4.3, tuple.X);
        Assert.Equal(-4.2, tuple.Y);
        Assert.Equal(3.1, tuple.Z);
        Assert.Equal(0.0, tuple.W);
        Assert.False(tuple.IsPoint);
        Assert.True(tuple.IsVector);
    }

    // Equality
    [Fact]
    public void Point_EqualsVector_IsNotEqual()
    {
        Tuple vector = Tuple.Vector(4.3, -4.2, 3.1);
        Tuple point = Tuple.Point(4.3, -4.2, 3.1);

        Assert.False(point.Equals(vector));
        Assert.False(vector.Equals(point));
    }

    [Fact]
    public void Tuple_EqualsNullTuple_IsNotEqual()
    {
        Tuple t1 = new Tuple(4.3, -4.2, 3.1, 1.0);
        Tuple t2 = (Tuple) null;

        Assert.False(t1.Equals(t2));
    }

    [Fact]
    public void Tuples_WithSameValues_AreEqual()
    {
        Tuple t1 = new Tuple(4.3, -4.2, 3.1, 1.0);
        Tuple t2 = new Tuple(4.3, -4.2, 3.1, 1.0);

        Assert.True(t1.Equals(t2));
        Assert.True(t2.Equals(t1));
    }

    [Fact]
    public void Tuples_WithSameValuesWithinPoint00001_AreEqual()
    {
        double epsilon = 0.00001;
        Tuple t1 = new Tuple(4.3 + epsilon, -4.2, 3.1, 1.0);
        Tuple t2 = new Tuple(4.3, -4.2, 3.1, 1.0);

        Assert.True(t1.Equals(t2));
        Assert.True(t2.Equals(t1));
    }

    [Fact]
    public void Tuples_WithSameValuesWithinPoint00001_AreNotEqual()
    {
        double epsilon = 0.000011;
        Tuple t1 = new Tuple(4.3 + epsilon, -4.2, 3.1, 1.0);
        Tuple t2 = new Tuple(4.3, -4.2, 3.1, 1.0);

        Assert.False(t1.Equals(t2));
        Assert.False(t2.Equals(t1));
    }
}
