using Xunit;
using TupleLibrary;

namespace TupleTests;
public class MatrixTests
{
    [Fact]
    public void Matrix_construct_a_4x4_matrix()
    {
       var elements = new double [4,4] {
            {1   , 2   , 3   , 4   },
            {5.5 , 6.5 , 7.5 , 8.5 },
            {9   , 10  , 11  , 12  },
            {13.5, 14.5, 15.5, 16.5},
        };

        Matrix matrix = new Matrix(elements);

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
            {-3,  5},
            { 1, -2},
        };

        Matrix matrix = new Matrix(elements);

        Assert.Equal(-3, matrix.Element(0,0));
        Assert.Equal(5, matrix.Element(0,1));
        Assert.Equal(1, matrix.Element(1,0));
        Assert.Equal(-2, matrix.Element(1,1));
    }

    [Fact]
    public void Matrix_construct_a_3x3_matrix()
    {
       var elements = new double [3,3] {
            {-3,  5,  0},
            { 1, -2, -7},
            { 0,  1,  1}
        };

        Matrix matrix = new Matrix(elements);

        Assert.Equal(-3, matrix.Element(0,0));
        Assert.Equal(-2, matrix.Element(1,1));
        Assert.Equal(1, matrix.Element(2,2));
    }

    // equality
    [Fact]
    public void Matrix_equality_with_equal_matrices()
    {
       var elements = new double [3,3] {
            {-3,  5,  0},
            { 1, -2, -7},
            { 0,  1,  1}
        };

        Matrix m1 = new Matrix(elements);
        Matrix m2 = new Matrix(elements);

        Assert.True(m1.Equals(m2));
        Assert.True(m2.Equals(m1));
    }

    [Fact]
    public void Matrix_equality_with_different_matrices()
    {
       var elements = new double [3,3] {
            {-3,  5,  0},
            { 1, -2, -7},
            { 0,  1,  1}
        };

        var elements2 = new double [3,3] {
            {-3,  5,  0},
            { 1, -2, -7},
            { 0,  1,  8}
        };

        Matrix m1 = new Matrix(elements);
        Matrix m2 = new Matrix(elements2);

        Assert.False(m1.Equals(m2));
        Assert.False(m2.Equals(m1));
    }

    // nearly equal flaoting point numbers, consider EPSILON
    // TODO: for some reason this fails when using epsilon 0.00001, which does not fail in Tuple Tests, why?
    [Fact]
    public void Matrix_equality_with_practically_equal_matrices()
    {
        double epsilon = 0.00000999;
        var e1 = new double [1,1] {
            {3}
        };

        var e2 = new double [1,1] {
            {3 + epsilon}
        };

        Matrix m1 = new Matrix(e1);
        Matrix m2 = new Matrix(e2);

        Assert.True(m1.Equals(m2));
        Assert.True(m2.Equals(m1));

    }

    [Fact]
    public void Matrix_equality_with_just_inequal_matrices()
    {
        double epsilon = 0.000010;
        var e1 = new double [1,1] {
            {3}
        };

        var e2 = new double [1,1] {
            {3 + epsilon}
        };

        Matrix m1 = new Matrix(e1);
        Matrix m2 = new Matrix(e2);

        Assert.False(m1.Equals(m2));
        Assert.False(m2.Equals(m1));
    }

    [Fact]
    public void Matrix_equality_with_different_size_matrices()
    {
       var elements = new double [3,3] {
            {-3,  5,  0},
            { 1, -2, -7},
            { 0,  1,  1}
        };

        var elements2 = new double [2,3] {
            {-3,  5,  0},
            { 1, -2, -7}
        };

        Matrix m1 = new Matrix(elements);
        Matrix m2 = new Matrix(elements2);

        Assert.False(m1.Equals(m2));
        Assert.False(m2.Equals(m1));
    }

    //multiplication

    [Fact]
    public void Multiplying_two_matrices()
    {
        var elements = new double [4,4] {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 8, 7, 6},
            {5, 4, 3, 2}
        };

        var elements2 = new double [4,4] {
            {-2, 1, 2,  3},
            { 3, 2, 1, -1},
            { 4, 3, 6,  5},
            { 1, 2, 7,  8}
        };

        var elements3 = new double [4,4] {
            {20, 22,  50,  48},
            {44, 54, 114, 108},
            {40, 58, 110, 102},
            {16, 26,  46,  42}
        };

        Matrix m1 = new Matrix(elements);
        Matrix m2 = new Matrix(elements2);
        Matrix expected = new Matrix(elements3);
        Matrix m3 = m1 * m2;

        Assert.Equal(expected, m3);
    }

    [Fact]
    public void Multiplying_two_matrices_with_different_lengths()
    {
        var elements = new double [2,2] {
            {1, 2},
            {5, 6}
        };

        var elements2 = new double [4,4] {
            {-2, 1, 2,  3},
            { 3, 2, 1, -1},
            { 4, 3, 6,  5},
            { 1, 2, 7,  8}
        };

        Matrix m1 = new Matrix(elements);
        Matrix m2 = new Matrix(elements2);

        Assert.Throws<System.ArgumentException>(() => m1 * m2);
    }

    [Fact]
    public void Multiplying_a_matrix_by_the_identity_matrix()
    {
        var elements = new double [4,4] {
            {0, 1, 2 , 4 },
            {1, 2, 4 , 8 },
            {2, 4, 8 , 16},
            {4, 8, 16, 32}
        };

        var identityElements = new double [4,4] {
            {1,0,0,0},
            {0,1,0,0},
            {0,0,1,0},
            {0,0,0,1},
        };

        Matrix m1 = new Matrix(elements);
        Matrix identity = new Matrix(identityElements);

        Matrix m3 = m1 * identity;

        Assert.Equal(m1, m3);
    }

    [Fact]
    public void Multiplying_identity_matrix_by_a_tuple()
    {
        var identityElements = new double [4,4] {
            {1,0,0,0},
            {0,1,0,0},
            {0,0,1,0},
            {0,0,0,1},
        };

        Tuple t1 = new Tuple(1, 2, 3, 4);
        Matrix identity = new Matrix(identityElements);

        Tuple t2 = identity * t1;

        Assert.Equal(t1, t2);
    }

    [Fact]
    public void Multiplying_a_matrix_by_a_tuple()
    {
        var elements = new double [4,4] {
            {1, 2, 3, 4},
            {2, 4, 4, 2},
            {8, 6, 4, 1},
            {0, 0, 0, 1}
        };

        Matrix m1 = new Matrix(elements);
        Tuple t1 = new Tuple(1, 2, 3, 1);
        Tuple expected = new Tuple(18, 24, 33, 1);
        Tuple t2 = m1 * t1;

        Assert.Equal(expected, t2);
    }

    [Fact]
    public void Transposing_a_matrix()
    {
        var elements = new double [4,4] {
            {0,9,3,0},
            {9,8,0,8},
            {1,8,5,3},
            {0,0,5,8}
        };

        var tElements = new double [4,4] {
            {0,9,1,0},
            {9,8,8,0},
            {3,0,5,5},
            {0,8,3,8}
        };

        Matrix m1 = new Matrix(elements);
        Matrix expected = new Matrix(tElements);

        Matrix m2 = m1.Transpose();

        Assert.Equal(expected, m2);
    }

    [Fact]
    public void Transpose_identity_matrix()
    {
        var identityElements = new double [4,4] {
            {1,0,0,0},
            {0,1,0,0},
            {0,0,1,0},
            {0,0,0,1},
        };

        Matrix identity = new Matrix(identityElements);
        Matrix expected = new Matrix(identityElements);

        Matrix m2 = identity.Transpose();

        Assert.Equal(expected, m2);
    }
}