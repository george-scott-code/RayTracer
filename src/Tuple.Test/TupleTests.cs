using Xunit;
using TupleLibrary;

namespace TupleTests;

public class TupleTests
{
    // creation
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

    //Addition

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

    // Subtraction

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
