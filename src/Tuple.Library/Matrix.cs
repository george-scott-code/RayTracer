using System;

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
        this.Elements == matrix.Elements;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Elements);
    }
}
