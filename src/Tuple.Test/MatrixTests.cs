using Xunit;
using TupleLibrary;

namespace TupleTests;
public class MatrixTests
{
    [Fact]
    public void Matrix_construct_a_4x4_matrix()
    {
       var elements = new double [4,4] {
            {1, 2, 3, 4},
            {5.5, 6.5, 7.5, 8.5},
            {9, 10, 11, 12},
            {13.5, 14.5, 15.5, 16.5},
        };

        Matrix matrix = new Matrix(4, 4, elements);

        Assert.Equal(1, matrix.Element(0,0));
        Assert.Equal(4, matrix.Element(0,3));
        Assert.Equal(5.5, matrix.Element(1,0));
        Assert.Equal(7.5, matrix.Element(1,2));
        Assert.Equal(11, matrix.Element(2,2));
        Assert.Equal(13.5, matrix.Element(3,0));
        Assert.Equal(15.5, matrix.Element(3,2));
    }

    [Fact]
    public void Matrix_construct_a_2x2_matrix()
    {
       var elements = new double [2,2] {
            {-3, 5},
            {1, -2},
        };

        Matrix matrix = new Matrix(2, 2, elements);

        Assert.Equal(-3, matrix.Element(0,0));
        Assert.Equal(5, matrix.Element(0,1));
        Assert.Equal(1, matrix.Element(1,0));
        Assert.Equal(-2, matrix.Element(1,1));
    }

    [Fact]
    public void Matrix_construct_a_3x3_matrix()
    {
       var elements = new double [3,3] {
            {-3, 5, 0},
            {1, -2, -7},
            {0, 1, 1}
        };

        Matrix matrix = new Matrix(2, 2, elements);

        Assert.Equal(-3, matrix.Element(0,0));
        Assert.Equal(-2, matrix.Element(1,1));
        Assert.Equal(1, matrix.Element(2,2));
    }

    [Fact]
    public void Matrix_equality_with_equal_matrices()
    {
       var elements = new double [3,3] {
            {-3, 5, 0},
            {1, -2, -7},
            {0, 1, 1}
        };

        Matrix m1 = new Matrix(2, 2, elements);
        Matrix m2 = new Matrix(2, 2, elements);

        Assert.True(m1.Equals(m2));
    }

    [Fact]
    public void Matrix_equality_with_different_matrices()
    {
       var elements = new double [3,3] {
            {-3, 5, 0},
            {1, -2, -7},
            {0, 1, 1}
        };

        var elements2 = new double [3,3] {
            {-3, 5, 0},
            {1, -2, -7},
            {0, 1, 8}
        };

        Matrix m1 = new Matrix(2, 2, elements);
        Matrix m2 = new Matrix(2, 2, elements2);

        Assert.False(m1.Equals(m2));
    }
}