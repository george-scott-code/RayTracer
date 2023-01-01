using Xunit;
using TupleLibrary;
using System.Collections.Generic;
using System;

namespace TupleTests;
public class MatrixTests
{
    [Fact]
    public void Matrix_construct_a_matrix()
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
}

internal class Matrix
{
    private int v1;
    private int v2;
    private double[,] elements;

    public Matrix(int v1, int v2, double[,] elements)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.elements = elements;
    }

    internal double Element(int v1, int v2)
    {
         throw new NotImplementedException();
    }
}