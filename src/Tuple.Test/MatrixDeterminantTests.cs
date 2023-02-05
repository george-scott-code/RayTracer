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
            {-3, 2},
            { 0, 6},
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

    // minor

    [Fact]
    public void Calculate_minor_of_a_3x3_matrix()
    {
        var elements = new double [3,3] {
            { 3,  5,  0},
            { 2, -1, -7},
            { 6, -1,  5}
        };
        Matrix a = new Matrix(elements);
        Matrix b = a.Submatrix(1, 0);

        var determinant = b.Determinant();
        var minor = a.Minor(1, 0);

        Assert.Equal(determinant, minor);
    }

    //cofactors
    
    [Fact]
    public void Calculate_cofactor_of_a_3x3_matrix()
    {
        var elements = new double [3,3] {
            { 3,  5,  0},
            { 2, -1, -7},
            { 6, -1,  5}
        };
        Matrix a = new Matrix(elements);

        Assert.Equal(-12, a.Minor(0, 0));
        Assert.Equal(-12, a.Cofactor(0, 0));
        Assert.Equal(25, a.Minor(1, 0));
        Assert.Equal(-25, a.Cofactor(1, 0));
    }

    [Fact]
    public void Calculate_determinant_of_a_4x4_matrix()
    {
        var elements = new double [4,4] {
            { -2, -8,  3,  5 },
            { -3,  1,  7,  3 },
            {  1,  2, -9,  6 },
            { -6,  7,  7, -9 }
        };
        Matrix a = new Matrix(elements);

        Assert.Equal(690, a.Cofactor(0, 0));
        Assert.Equal(447, a.Cofactor(0, 1));
        Assert.Equal(210, a.Cofactor(0, 2));
        Assert.Equal(51, a.Cofactor(0, 3));
        Assert.Equal(-4071, a.Determinant());
    }
}