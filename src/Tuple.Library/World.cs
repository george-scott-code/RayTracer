namespace TupleLibrary;

public class World
{
    public PointLight Light { get; set; }
    public World()
    {
        
    }
}


public static class DefaultWorld
{
    public static World World { get; set; } = new World();
}
