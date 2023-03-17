namespace TupleLibrary;
public class Ray
{
    public Ray(Tuple origin, Tuple direction)
    {
        this.Origin = origin;
        this.Direction = direction;
    }

    public Tuple Origin { get; }
    public Tuple Direction { get; }

    public Tuple Position(double t)
    {
        return Origin.Add(this.Direction * t);
    }
}