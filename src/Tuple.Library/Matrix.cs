using System;
using TupleLibrary.Extensions;

namespace TupleLibrary;

public class Matrix
{
    private int rowLength;
    private int colLength;
    public double[,] Elements {get; private set;}

    public Matrix(double[,] elements)
    {
        this.rowLength = elements.GetLength(0);
        this.colLength = elements.GetLength(1);
        this.Elements = elements;
    }

    public static Matrix operator *(Matrix a, Matrix b) => MultiplyMatrices(a, b);

    public static Tuple operator *(Matrix m, Tuple t) => MultiplyTuple(m ,t);

    private static Tuple MultiplyTuple(Matrix m, Tuple t)
    {
        var tElements = t.ToArray();

        double[] tuple = new double[4];
        for(int row = 0; row < 4; row++)
        {
            double sum = 0;
            for(int col = 0; col < 4; col++)
            {
                sum += m.Element(row, col) * tElements[col];
            }
            tuple[row] = sum;
        }
        return new Tuple(tuple[0], tuple[1], tuple[2], tuple[3]);
    }

    private static Matrix MultiplyMatrices(Matrix a, Matrix b)
    {
        double[,] elements = new double[a.rowLength, a.colLength];

        if (a.rowLength != b.colLength)
        {
            throw new ArgumentException("Cannot multiply matrices of different lengths");
        }

        for(int row = 0; row < a.rowLength; row++)
        {
            for(int col = 0; col < b.colLength; col++)
            {
                double sum = 0;
                for(int i = 0; i < a.rowLength; i++)
                {
                    sum += (a.Element(row, i) * b.Element(i, col));
                }
                elements[row, col] = sum;
            }
        }
        return new Matrix(elements);
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
        if(this.rowLength != matrix.rowLength || this.colLength != matrix.colLength) {
            return false;
        }

        for(int i = 0; i < this.rowLength; i++)
        {
            for(int j = 0; j < this.colLength; j++)
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

    public Matrix Transpose()
    {
        double[,] elements = new double[this.rowLength, this.colLength];

        for(int row = 0; row < this.rowLength; row++)
        {
            for(int col = 0; col < this.colLength; col++)
            {
                elements[col, row] = this.Element(row, col);
            }
        }
        return new Matrix(elements);
    }

    public double Determinant()
    {
        if(this.rowLength == 2 && this.colLength == 2)
        {
            var a = this.Element(0, 0);
            var b = this.Element(0, 1);
            var c = this.Element(1, 0);
            var d = this.Element(1, 1);

            return (a*d) - (b*c);
        }
        throw new NotImplementedException();
    }

    public Matrix Submatrix(int sRow, int sCol)
    {
        double[,] elements = new double[this.rowLength -1, this.colLength];
        var rowSkipped = false;
        for(int row = 0; row < this.rowLength; row++)
        {
            if(row == sRow)
            {
                rowSkipped = true;
                continue;
            }
            var colSkipped = false;
            for(int col = 0; col < this.colLength; col++)
            {
                // if(col == sCol)
                // {
                //     colSkipped = true;
                //     continue;
                // }
                elements[rowSkipped ? row - 1 : row, col] = this.Element(row, col);
            }
        }
        return new Matrix(elements);
    }
}
