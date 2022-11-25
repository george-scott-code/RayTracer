public class Projectile
{
    public Projectile(TupleLibrary.Tuple startPosition, TupleLibrary.Tuple startVelocity)
    {
        this.Position = startPosition;
        this.Velocity = startVelocity;
    }
    TupleLibrary.Tuple Position {get; set;}
    TupleLibrary.Tuple Velocity {get; set;}
}