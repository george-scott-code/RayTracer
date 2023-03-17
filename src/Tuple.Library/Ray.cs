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
}