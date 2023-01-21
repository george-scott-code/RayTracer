using Xunit;
using TupleLibrary;

namespace TupleTests;
public class MatrixDeterminantTests
{
    [Fact]
    public void Calculating_the_determinant_of_a_2x2_matrix()
    {
        var elements = new double [2,2] {
            { 1, 5},
            {-3, 2}
        };

        Matrix m1 = new Matrix(elements);
        double determinate = m1.Determinant();

        Assert.Equal(17, determinate);
    }
}