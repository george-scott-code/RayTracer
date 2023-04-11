using System.Collections.Generic;

namespace TupleLibrary;

public class World
{
    public PointLight Light { get; set; }
    public List<Sphere> Objects { get; set; }

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

        var s1 = new Sphere();
        return world;
    }
}
