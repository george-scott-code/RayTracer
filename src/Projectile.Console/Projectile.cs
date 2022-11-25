public class Projectile
{
    public Projectile(TupleLibrary.Tuple startPosition, TupleLibrary.Tuple startVelocity)
    {
        this.Position = startPosition;
        this.Velocity = startVelocity;
    }
    public TupleLibrary.Tuple Position {get; set;}
    public TupleLibrary.Tuple Velocity {get; set;}
}