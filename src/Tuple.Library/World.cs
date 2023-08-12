using System.Collections.Generic;
using Xunit;

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
        var world = new World
        {
            Light = new PointLight(Tuple.Point(-10, 10, -10), new Color(1, 1, 1))
        };

        Material m1 = new(new Color(0.8, 1.0, 0.6), 0.1, 0.7, 0.2, 200.00);

        var transform = Matrix.Scaling(0.5, 0.5, 0.5);

        world.Objects.Add(new Sphere(m1));
        world.Objects.Add(new Sphere(transform));

        return world;
    }
}

// Scenario: Creating a worlds
// Given w ← world()
// Then w contains no objects
// And w has no light source

public class WorldTests
{
    [Fact]
    public void CreatingAWorld()
    {
        var world = new World();
        Assert.Empty(world.Objects);
        Assert.Null(world.Light);
    }
}