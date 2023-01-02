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

        Assert.Equal(matrix.Element(0,0), 1);
        Assert.Equal(matrix.Element(0,3), 4);
        Assert.Equal(matrix.Element(1,0), 5.5);
        Assert.Equal(matrix.Element(1,2), 7.5);
        Assert.Equal(matrix.Element(2,2), 11);
        Assert.Equal(matrix.Element(3,0), 13.5);
        Assert.Equal(matrix.Element(3,2), 15.5);
    }

    [Fact]
    public void Matrix_construct_a_2x2_matrix()
    {
       var elements = new double [2,2] {
            {-3, 5},
            {1, -2},
        };

        Matrix matrix = new Matrix(2, 2, elements);

        Assert.Equal(matrix.Element(0,0), -3);
        Assert.Equal(matrix.Element(0,1), 5);
        Assert.Equal(matrix.Element(1,0), 1);
        Assert.Equal(matrix.Element(1,1), -2);
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

        Assert.Equal(matrix.Element(0,0), -3);
        Assert.Equal(matrix.Element(1,1), -2);
        Assert.Equal(matrix.Element(2,2), 1);
    }
}