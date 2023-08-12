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

public class WorldTests
{
    // Scenario: Creating a worlds
    // Given w ← world()
    // Then w contains no objects
    // And w has no light source
    [Fact]
    public void CreatingAWorld()
    {
        var world = new World();
        Assert.Empty(world.Objects);
        Assert.Null(world.Light);
    }

    // Scenario: The default world
    // Given light ← point_light(point(-10, 10, -10), color(1, 1, 1))
    // And s1 ← sphere() with:
    // | material.color | (0.8, 1.0, 0.6) |
    // | material.diffuse | 0.7 |
    // | material.specular | 0.2 |
    // And s2 ← sphere() with:s
    // | transform | scaling(0.5, 0.5, 0.5) |
    // When w ← default_world()
    // Then w.light = light
    // And w contains s1
    // And w contains s2
    [Fact]
    public void CreatingADefaultWorld()
    {
        var light = new PointLight(Tuple.Point(-10, 10, -10), new Color(1, 1, 1));
        var s1 = new Sphere
        {
            Material = new(new Color(0.8, 1.0, 0.6), 0.1, 0.7, 0.2, 200.00)
        };
        var s2 = new Sphere
        {
            Transform = Matrix.Scaling(0.5, 0.5, 0.5)
        };

        var world = World.GetDefaultWorld();
        Assert.Equivalent(light, world.Light);
        Assert.Contains(s1, world.Objects);
        Assert.Contains(s2, world.Objects);
    }
}