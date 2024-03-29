using System;
using TupleLibrary.Extensions;

namespace TupleLibrary;

public class Matrix
{
    private readonly int rowLength;
    private readonly int colLength;
    public double[,] Elements {get; private set;}

    public Matrix(double[,] elements)
    {
        rowLength = elements.GetLength(0);
        colLength = elements.GetLength(1);
        Elements = elements;
    }

    public static Matrix operator *(Matrix a, Matrix b) => MultiplyMatrices(a, b);

    public static Tuple operator *(Matrix m, Tuple t) => MultiplyTuple(m ,t);

    public static Ray operator *(Matrix m, Ray r) => MultiplyRay(m , r);

    private static Tuple MultiplyTuple(Matrix m, Tuple t)
    {
        var tElements = t.ToArray();

        double[] tuple = new double[4];
        for (int row = 0; row < 4; row++)
        {
            double sum = 0;
            for (int col = 0; col < 4; col++)
            {
                sum += m.Element(row, col) * tElements[col];
            }
            tuple[row] = sum;
        }
        return new Tuple(tuple[0], tuple[1], tuple[2], tuple[3]);
    }

    private static Ray MultiplyRay(Matrix m, Ray r)
    {
        return new Ray(m * r.Origin, m * r.Direction);
    }

    private static Matrix MultiplyMatrices(Matrix a, Matrix b)
    {
        double[,] elements = new double[a.rowLength, a.colLength];

        if (a.rowLength != b.colLength)
        {
            throw new ArgumentException("Cannot multiply matrices of different lengths");
        }

        for (int row = 0; row < a.rowLength; row++)
        {
            for (int col = 0; col < b.colLength; col++)
            {
                double sum = 0;
                for (int i = 0; i < a.rowLength; i++)
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
        if(rowLength != matrix.rowLength || this.colLength != matrix.colLength) {
            return false;
        }

        for (int i = 0; i < this.rowLength; i++)
        {
            for (int j = 0; j < this.colLength; j++)
            {
                if(!this.Element(i, j).DEquals(matrix.Element(i, j)))
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

        for (int row = 0; row < this.rowLength; row++)
        {
            for (int col = 0; col < this.colLength; col++)
            {
                elements[col, row] = this.Element(row, col);
            }
        }
        return new Matrix(elements);
    }

    public double Determinant()
    {
        if(rowLength == 2 && this.colLength == 2)
        {
            var a = this.Element(0, 0);
            var b = this.Element(0, 1);
            var c = this.Element(1, 0);
            var d = this.Element(1, 1);

            return (a*d) - (b*c);
        }
        double det = 0;
        for (int col = 0; col < this.colLength; col ++)
        {
            det += this.Element(0, col) * this.Cofactor(0, col);
        }
        return det;
    }

    public Matrix Submatrix(int sRow, int sCol)
    {
        if(sRow >= this.rowLength || sCol >= this.colLength)
        {
            throw new ArgumentException();
        }
        
        double[,] elements = new double[this.rowLength -1, this.colLength -1];
        var rowSkipped = false;
        for (int row = 0; row < this.rowLength; row++)
        {
            if(row == sRow)
            {
                rowSkipped = true;
                continue;
            }
            var colSkipped = false;
            for (int col = 0; col < this.colLength; col++)
            {
                if(col == sCol)
                {
                    colSkipped = true;
                    continue;
                }
                elements[rowSkipped ? row - 1 : row, colSkipped ? col - 1 : col] = this.Element(row, col);
            }
        }
        return new Matrix(elements);
    }

    public double Minor(int row, int col)
    {
        Matrix sub = this.Submatrix(row, col);

        return sub.Determinant();
    }

    public double Cofactor(int row, int col)
    {
        var minor = this.Minor(row, col);
        return (row + col) % 2 == 0 ? minor : (0 - minor);
    }

    public bool IsInvertable()
    {
        return this.Determinant() != 0;
    }

    public Matrix Inverse()
    {
        if (!this.IsInvertable())
        {
            throw new Exception("not invertible");
        }
        double[,] elements = new double[this.rowLength, this.colLength];
        var d = this.Determinant();

        for (int row = 0; row < this.rowLength; row++)
        {
            for (int col = 0; col < this.colLength; col++)
            {
                var c = this.Cofactor(row, col);
                elements[col, row] = c / d;
            }
        }
        return new Matrix(elements);
    }

    public static Matrix Translation(double x, double y, double z)
    {
        double[,] elements = new double[4,4]
        {
            {1, 0, 0, x},
            {0, 1, 0, y},
            {0, 0, 1, z},
            {0, 0, 0, 1},
        };
        return new Matrix(elements);
    }

    public static Matrix Scaling(double x, double y, double z)
    {
        double[,] elements = new double[4,4]
        {
            {x, 0, 0, 0},
            {0, y, 0, 0},
            {0, 0, z, 0},
            {0, 0, 0, 1},
        };
        return new Matrix(elements);
    }

    public static Matrix RotationX(double r)
    {
        var sinR = Math.Sin(r);
        var cosR = Math.Cos(r);

        double[,] elements = new double[4,4]
        {
            {1,    0,      0, 0},
            {0, cosR, 0-sinR, 0},
            {0, sinR,   cosR, 0},
            {0,    0,      0, 1},
        };
        return new Matrix(elements);
    }

    public static Matrix RotationY(double r)
    {
        var sinR = Math.Sin(r);
        var cosR = Math.Cos(r);

        double[,] elements = new double[4,4]
        {
            {cosR  , 0 , sinR, 0},
            {0     , 1 , 0   , 0},
            {0-sinR, 0 , cosR, 0},
            {0     , 0 , 0   , 1},
        };
        return new Matrix(elements);
    }

    public static Matrix RotationZ(double r)
    {
        var sinR = Math.Sin(r);
        var cosR = Math.Cos(r);

        double[,] elements = new double[4,4]
        {
            {cosR , -sinR, 0 , 0},
            {sinR , cosR , 0 , 0},
            {0    , 0    , 1 , 0},
            {0    , 0    , 0 , 1},
        };
        return new Matrix(elements);
    }

    public static Matrix Shearing(int xy, int xz, int yx, int yz, int zx, int zy)
    {
        double[,] elements = new double[4,4]
        {
            {1 , xy, xz, 0},
            {yx, 1 , yz, 0},
            {zx, zy, 1 , 0},
            {0 , 0 , 0 , 1},
        };
        return new Matrix(elements);
    }

    public static Matrix Identity()
    {
        var identityElements = new double [4,4] {
            {1,0,0,0},
            {0,1,0,0},
            {0,0,1,0},
            {0,0,0,1},
        };

        return new Matrix(identityElements);
    }

    public static Matrix ViewTransform(TupleLibrary.Tuple from, TupleLibrary.Tuple to, TupleLibrary.Tuple up)
    {
        var forward = to.Subtract(from).Normalize();
        var upn = up.Normalize();
        var left = forward.Cross(upn);
        var true_up = left.Cross(forward);

        var orientationElements = new double [4,4] {
            { left.X    , left.Y    , left.Z    , 0},
            { true_up.X , true_up.Y , true_up.Z , 0},
            { -forward.X, -forward.Y, -forward.Z, 0},
            { 0         , 0         , 0         , 1},
        };
        var orientation = new Matrix(orientationElements);
        return orientation * Translation(-from.X, -from.Y, -from.Z);
    }
}
