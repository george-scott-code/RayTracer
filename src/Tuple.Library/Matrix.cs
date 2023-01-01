namespace TupleLibrary;

public class Matrix
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

    public double Element(int v1, int v2)
    {
        return elements[v1, v2];
    }
}
