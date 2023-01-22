using Xunit;
using TupleLibrary;

namespace TupleTests;
public class MatrixInvertTests
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

    //submatrices

    [Fact]
    public void A_submatrix_of_a_3x3_matrix_is_a_2x2_matrix()
    {
        var elements = new double [3,3] {
            { 1, 5,  0},
            {-3, 2,  7},
            { 0, 6, -3}
        };

        var expectedElements = new double [2,2] {
            { 0, 6},
            {-3, 2},
        };

        Matrix m1 = new Matrix(elements);
        Matrix submatrix = m1.Submatrix(0, 2);
        Matrix expected = new Matrix(expectedElements);

        Assert.Equal(expected, submatrix);
    }

    [Fact]
    public void A_submatrix_of_a_4x4_matrix_is_a_3x3_matrix()
    {
        var elements = new double [4,4] {
            { -6, 1,  1, 6 },
            { -8, 5,  8, 6 },
            { -1, 0,  8, 2 },
            { -7, 1, -1, 1 },
        };

        var expectedElements = new double [3,3] {
            {-6,  1 , 6 },
            {-8,  8 , 6 },
            {-7, -1 , 1 },
        };

        Matrix m1 = new Matrix(elements);
        Matrix submatrix = m1.Submatrix(2, 1);
        Matrix expected = new Matrix(expectedElements);

        Assert.Equal(expected, submatrix);
    }
}