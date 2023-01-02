namespace TupleLibrary;

public class Matrix
{
    private int v1;
    private int v2;
    public double[,] Elements {get; private set;}

    public Matrix(int v1, int v2, double[,] elements)
    {
        this.v1 = v1;
        this.v2 = v2;
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
}
