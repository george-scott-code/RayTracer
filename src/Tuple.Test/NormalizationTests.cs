using Xunit;
using TupleLibrary;

namespace TupleTests;
public class NormalizationTests
{
    [Fact]
    public void Normalizing_vector_4_0_0()
    {
        // Given
        Tuple t1 = Tuple.Vector(4, 0, 0);
        // When
        Tuple result = t1.Normalize();
        // Then
        Tuple expected = Tuple.Vector(1,0,0);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Normalizing_vector_1_2_3()
    {
        // Given
        Tuple t1 = Tuple.Vector(1, 2, 3);
        // When
        Tuple result = t1.Normalize();
        // Then
        Tuple expected = Tuple.Vector(0.26726, 0.53452, 0.80178);
        //use equals method to cater for rounding of doubles
        Assert.True(expected.Equals(result));
    }

    [Fact]
    public void Normalized_vector_is_unit_vector()
    {
        // Given
        Tuple t1 = Tuple.Vector(1, 2, 3);
        // When
        Tuple normalized = t1.Normalize();
        // Then
        double result = normalized.Magnitude();
        Assert.Equal(1.0, result);
    }
}
