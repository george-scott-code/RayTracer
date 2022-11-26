namespace TupleLibrary;

public class Color
{
    private double v1;
    private double v2;
    private double v3;

    public Color(double v1, double v2, double v3)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
    }

    public double Red { get; set; }
    public double Green { get; set; }
    public double Blue { get; set; }
}
