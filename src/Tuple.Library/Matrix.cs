using System;
using TupleLibrary.Extensions;

namespace TupleLibrary;

public class Matrix
{
    private int v1;
    private int v2;
    public double[,] Elements {get; private set;}

    public Matrix(double[,] elements)
    {
        this.v1 = elements.GetLength(0);
        this.v2 = elements.GetLength(1);
        this.Elements = elements;
    }

    public static Matrix operator *(Matrix a, Matrix b) => MultiplyMatrices(a, b);

    private static Matrix MultiplyMatrices(Matrix a, Matrix b)
    {
        
        return new Matrix(new double[0, 0]{});
    }

    public double Element(int v1, int v2)
    {
        return Elements[v1, v2];
    }

    public override bool Equals(object obj)
    {
        if(obj is null != this is null)
        {
            return false;
        }
        if(obj is null && this is null)
        {
            return true;
        }
        return obj is Matrix matrix &&
        this.ElementsDEqual(matrix);
    }

    private bool ElementsDEqual(Matrix matrix)
    {
        if(this.v1 != matrix.v1 || this.v2 != matrix.v2) {
            return false;
        }

        for(int i = 0; i < this.v1; i++)
        {
            for(int j = 0; j < this.v2; j++)
            {
                if(!this.Element(i, j).DEquals(matrix.Element(i,j)))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Elements);
    }
}
