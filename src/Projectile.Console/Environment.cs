public class Environment
{
    public Environment(TupleLibrary.Tuple gravity, TupleLibrary.Tuple wind)
    {
        this.Gravity = gravity;
        this.Wind = wind;
    }
    
    public TupleLibrary.Tuple Gravity { get; set; }
    public TupleLibrary.Tuple Wind { get; set; }
}