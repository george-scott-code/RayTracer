namespace TupleLibrary;

public class Intersection
{
    public Intersection(double t, object obj)
    {
        this.T = t;
        this.Obj = obj;
    }

    public double T { get; private set; }
    public object Obj { get; private set; }
}

public static class Intersections
{
    public static Intersection Hit(this Intersection[] intersections)
    {
        return intersections[0];
    }
}