using Xunit;
using TupleLibrary;

namespace TupleTests;

public class VectorMagnitudeTests
{
    [Theory]
    [InlineData(1,0,0)]
    [InlineData(0,1,0)]
    [InlineData(0,0,1)]
    public void Computing_magnitude_of_unit_vectors(double x, double y, double z)
    {
        Tuple t1 = Tuple.Vector(x, y, z);

        double result = t1.Magnitude();

        Assert.Equal(1, result);
    }

    [Theory]
    [InlineData(1,2,3)]
    [InlineData(-1,-2,-3)]
    public void Computing_magnitude_of_vector(double x, double y, double z)
    {
        Tuple t1 = Tuple.Vector(x, y, z);

        double result = t1.Magnitude();
        double expected = System.Math.Sqrt(14);
        Assert.Equal(expected, result);
    }
}