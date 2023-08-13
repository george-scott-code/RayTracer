namespace TupleLibrary;

public class IntersectComputations
{
    public IntersectComputations(double t, Sphere obj)
    {
        this.T = t;
        this.Obj = obj;
    }

    public double T { get; private set; }
    public Sphere Obj { get; private set; }
    public Tuple Point { get; internal set; }
    public Tuple EyeV { get; internal set; }
    public Tuple NormalV { get; internal set; }
    public bool Inside { get; internal set; }
}