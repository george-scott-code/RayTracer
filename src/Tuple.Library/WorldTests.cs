using System.Linq;
using Xunit;

namespace TupleLibrary;

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

    // Scenario: Intersect a world with a ray
    // Given w ← default_world()
    // And r ← ray(point(0, 0, -5), vector(0, 0, 1))
    // When xs ← intersect_world(w, r)
    // Then xs.count = 4
    // And xs[0].t = 4
    // And xs[1].t = 4.5
    // And xs[2].t = 5.5
    // And xs[3].t = 6
    [Fact]
    public void Intersect_world_with_a_ray()
    {
        var world = World.GetDefaultWorld();
        var ray = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 0, 1));
        var xs = world.Intersect(ray);

        Assert.Equal(4, xs.Count());
        Assert.Equal(4, xs[0].T);
        Assert.Equal(4.5, xs[1].T);
        Assert.Equal(5.5, xs[2].T);
        Assert.Equal(6, xs[3].T);
    }

    // Scenario: Precomputing the state of an intersection
    // Given r ← ray(point(0, 0, -5), vector(0, 0, 1))
    // And shape ← sphere()
    // And i ← intersection(4, shape)
    // When comps ← prepare_computations(i, r)
    // Then comps.t = i.t
    // And comps.object = i.object
    // And comps.point = point(0, 0, -1)
    // And comps.eyev = vector(0, 0, -1)
    // And comps.normalv = vector(0, 0, -1)
    [Fact]
    public void Prepare_computations()
    {
        var ray = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 0, 1));
        var shape = new Sphere();
        var intersection = shape.Intersection(ray);

        var comps = intersection.Hit().PrepareComputations(ray);

        Assert.Equal(intersection.Hit().Obj, comps.Obj);
        Assert.Equal(TupleLibrary.Tuple.Point(0, 0, -1), comps.Point);
        Assert.Equal(TupleLibrary.Tuple.Vector(0, 0, -1), comps.EyeV);
        Assert.Equal(TupleLibrary.Tuple.Vector(0, 0, -1), comps.NormalV);
    }

    // Scenario: The hit, when an intersection occurs on the outside
    // Given r ← ray(point(0, 0, -5), vector(0, 0, 1))
    // And shape ← sphere()
    // And i ← intersection(4, shape)
    // When comps ← prepare_computations(i, r)
    // Then comps.inside = false
    [Fact]
    public void Prepare_computations_intersection_outside_obj()
    {
        var ray = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 0, 1));
        var shape = new Sphere();
        var intersection = shape.Intersection(ray);

        var comps = intersection.Hit().PrepareComputations(ray);

        Assert.False(comps.Inside);
    }

    // Scenario: The hit, when an intersection occurs on the inside
    // Given r ← ray(point(0, 0, 0), vector(0, 0, 1))
    // And shape ← sphere()
    // And i ← intersection(1, shape)
    // When comps ← prepare_computations(i, r)
    // Then comps.point = point(0, 0, 1)
    // And comps.eyev = vector(0, 0, -1)
    // And comps.inside = true
    // # normal would have been (0, 0, 1), but is inverted!
    // And comps.normalv = vector(0, 0, -1)
    [Fact]
    public void Prepare_computations_intersection_inside_obj()
    {
        var ray = new Ray(Tuple.Point(0, 0, 0), Tuple.Vector(0, 0, 1));
        var shape = new Sphere();
        var intersection = shape.Intersection(ray);

        var comps = intersection.Hit().PrepareComputations(ray);

        Assert.True(comps.Inside);
        Assert.Equal(TupleLibrary.Tuple.Point(0, 0, 1), comps.Point);
        Assert.Equal(TupleLibrary.Tuple.Vector(0, 0, -1), comps.EyeV);
        Assert.Equal(TupleLibrary.Tuple.Vector(0, 0, -1), comps.NormalV);
    }

    // Scenario: Shading an intersection
    // Given w ← default_world()
    // And r ← ray(point(0, 0, -5), vector(0, 0, 1))
    // And shape ← the first object in w
    // And i ← intersection(4, shape)
    // When comps ← prepare_computations(i, r)
    // And c ← shade_hit(w, comps)
    // Then c = color(0.38066, 0.47583, 0.2855)
    [Fact]
    public void Shading_an_intersection()
    {
        var world = World.GetDefaultWorld();
        var ray = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 0, 1));
        var shape = world.Objects.First();
        var intersection = shape.Intersection(ray);

        var comps = intersection.Hit().PrepareComputations(ray);
        var c = world.ShadeHit(comps);
        var expectedColor = new Color(0.38066, 0.47583, 0.2855);
        Assert.Equal(expectedColor, c);
    }

    // Scenario: Shading an intersection from the inside
    // Given w ← default_world()
    // And w.light ← point_light(point(0, 0.25, 0), color(1, 1, 1))
    // And r ← ray(point(0, 0, 0), vector(0, 0, 1))
    // And shape ← the second object in w
    // And i ← intersection(0.5, shape)
    // When comps ← prepare_computations(i, r)
    // And c ← shade_hit(w, comps)
    // Then c = color(0.90498, 0.90498, 0.90498)
    [Fact]
    public void Shading_an_intersection_from_inside()
    {
        var world = World.GetDefaultWorld();
        world.Light = new PointLight(Tuple.Point(0, 0.25, 0), new Color(1, 1, 1));
        var ray = new Ray(Tuple.Point(0, 0, 0), Tuple.Vector(0, 0, 1));
        var shape = world.Objects.Skip(1).First();
        var intersection = shape.Intersection(ray);

        var comps = intersection.Hit().PrepareComputations(ray);
        var c = world.ShadeHit(comps);
        var expectedColor = new Color(0.90498, 0.90498, 0.90498);
        Assert.Equal(expectedColor, c);
    }

    // Scenario: The color when a ray misses
    // Given w ← default_world()
    // And r ← ray(point(0, 0, -5), vector(0, 1, 0))
    // When c ← color_at(w, r)
    // Then c = color(0, 0, 0)
    [Fact]
    public void Color_at_when_ray_misses()
    {
        var world = World.GetDefaultWorld();
        var ray = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 1, 0));
        var c = world.ColorAt(ray);

        var expectedColor = new Color(0, 0, 0);
        Assert.Equal(expectedColor, c);
    }
}