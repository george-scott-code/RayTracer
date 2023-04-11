namespace TupleLibrary;

public class World
{
    public World()
    {
        
    }
}


public static class DefaultWorld
{
    public static World World { get; set; } = new World();
}
