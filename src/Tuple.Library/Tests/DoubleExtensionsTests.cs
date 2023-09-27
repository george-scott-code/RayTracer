using TupleLibrary.Extensions;
using Xunit;

namespace TupleLibrary.Tests;

public class DoubleExtensionsTests
{
    [Theory]
    [InlineData(5, 5)]
    [InlineData(5, 5.00001)]
    [InlineData(5, 4.99999)]
    public void DEquals_Should_Be_True(double a, double b)
    {
        Assert.True(a.DEquals(b));
    }

    [Theory]
    [InlineData(5, 4)]
    [InlineData(5, 5.00002)]
    [InlineData(5, 4.99998)]
    public void DEquals_Should_Be_False(double a, double b)
    {
        Assert.False(a.DEquals(b));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(0.000009)]
    [InlineData(-0.000009)]
    public void DZero_Should_Be_True(double a)
    {
        Assert.True(a.DZero());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(0.00001)]
    [InlineData(-0.00001)]
    public void DZero_Should_Be_False(double a)
    {
        Assert.False(a.DZero());
    }
}
