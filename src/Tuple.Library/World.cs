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
    public static World GetDefaultWorld()
    {
        var world = new World();
        world.Light = new PointLight(Tuple.Point(-10, 10, -10), new Color(1, 1, 1));
        return world;
    }
}
