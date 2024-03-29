using TupleLibrary.Shapes;

namespace TupleLibrary;

public class IntersectComputations
{
    public IntersectComputations(double t, Shape obj)
    {
        T = t;
        Obj = obj;
    }

    public double T { get; private set; }
    public Shape Obj { get; private set; }
    public Tuple Point { get; internal set; }
    public Tuple EyeV { get; internal set; }
    public Tuple NormalV { get; internal set; }
    public bool Inside { get; internal set; }
    public Tuple OverPoint { get; internal set; }
}
