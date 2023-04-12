using System.Collections.Generic;

namespace TupleLibrary;

public class World
{
    public PointLight Light { get; set; }
    public List<Sphere> Objects { get; set; } = new List<Sphere>();

    public World()
    {
        
    }

    public static World GetDefaultWorld()
    {
        var world = new World();
        world.Light = new PointLight(Tuple.Point(-10, 10, -10), new Color(1, 1, 1));

        Material m1 = new(new Color(0.8, 1.0, 0.6), 0.1, 0.7, 0.2, 200.00);

        var s1 = new Sphere(m1);

        world.Objects.Add(s1);
        return world;
    }
}
