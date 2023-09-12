using Xunit;

namespace TupleLibrary;

public class LightingTests
{
    // 	Given a material m
	// And a point (0, 0, 0) position

    // Scenario: Lighting with the eye between the light and the surface
	// Given a vector (0, 0, -1) eyev
	// And a vector (0, 0, -1) normalv
	// And a point_light(point(0, 0, -10), color(1, 1, 1)) light
	// When the color result is lighting (m, light, position, eyev, normalv)
	// Then the color result is color(1.9, 1.9, 1.9)
    [Fact]
    public void Lighting_EyeBetweenLightAndSurface()
    {
        var material = new Material();
        var position = Tuple.Point(0,0,0);

        var eyeV = Tuple.Vector(0, 0, -1);
        var normalV = Tuple.Vector(0, 0, -1);
        var light = new PointLight(Tuple.Point(0, 0, -10), new Color(1, 1, 1));
        
        var result = Lighting.GetLighting(material, light, position, eyeV, normalV);
        Assert.Equal(new Color(1.9, 1.9, 1.9), result);
    }

    // Scenario: Lighting with the surface in shadow
    // Given eyev ← vector(0, 0, -1)
    // And normalv ← vector(0, 0, -1)
    // And light ← point_light(point(0, 0, -10), color(1, 1, 1))
    // And in_shadow ← true
    // When result ← lighting(m, light, position, eyev, normalv, in_shadow)
    // Then result = color(0.1, 0.1, 0.1)
    [Fact]
    public void Lighting_EyeBetweenLightAndSurface_InShadow()
    {
        var material = new Material();
        var position = Tuple.Point(0,0,0);

        var eyeV = Tuple.Vector(0, 0, -1);
        var normalV = Tuple.Vector(0, 0, -1);
        var light = new PointLight(Tuple.Point(0, 0, -10), new Color(1, 1, 1));
        
        var result = Lighting.GetLighting(material, light, position, eyeV, normalV, true);
        Assert.Equal(new Color(0.1, 0.1, 0.1), result);
    }

    // Scenario: Lighting with the eye between light and surface, eye offset 45°
	// Given a vector (0, 0.707106, -0.707106) eyev
	// And a vector (0, 0, -1) normalv
	// And a point_light(point(0, 0, -10), color(1, 1, 1)) light
	// When the color result is lighting (m, light, position, eyev, normalv)
	// Then the color result is color(1.0, 1.0, 1.0)
    [Fact]
    public void Lighting_EyeBetweenLightAndSurface_EyeOffset()
    {
        var material = new Material();
        var position = Tuple.Point(0,0,0);

        var eyeV = Tuple.Vector(0, 0.707106, -0.707106);
        var normalV = Tuple.Vector(0, 0, -1);
        var light = new PointLight(Tuple.Point(0, 0, -10), new Color(1, 1, 1));
        
        var result = Lighting.GetLighting(material, light, position, eyeV, normalV);
        Assert.Equal(new Color(1.0, 1.0, 1.0), result);
    }

    // Scenario: Lighting with eye opposite surface, light offset 45°
	// Given a vector (0, 0, -1) eyev
	// And a vector (0, 0, -1) normalv
	// And a point_light(point(0, 10, -10), color(1, 1, 1)) light
	// When the color result is lighting (m, light, position, eyev, normalv)
	// Then the color result is color(0.7364, 0.7364, 0.7364)
    [Fact]
    public void Lighting_EyeBetweenLightAndSurface_LightOffset()
    {
        var material = new Material();
        var position = Tuple.Point(0,0,0);

        var eyeV = Tuple.Vector(0, 0, -1);
        var normalV = Tuple.Vector(0, 0, -1);
        var light = new PointLight(Tuple.Point(0, 10, -10), new Color(1, 1, 1));
        
        var result = Lighting.GetLighting(material, light, position, eyeV, normalV);
        Assert.Equal(new Color(0.7364, 0.7364, 0.7364), result);
    }

    // Scenario: Lighting with eye in the path of the reflection vector
	// Given a vector (0, -0.70710678118, -0.70710678118) eyev
	// And a vector (0, 0, -1) normalv
	// And a point_light(point(0, 10, -10), color(1, 1, 1)) light
	// When the color result is lighting (m, light, position, eyev, normalv)
	// Then the color result is color(1.6364, 1.6364, 1.6364)
    [Fact]
    public void Lighting_EyeInPathOfReflectionVector()
    {
        var material = new Material();
        var position = Tuple.Point(0,0,0);

        var eyeV = Tuple.Vector(0, -0.70710678118, -0.70710678118);
        var normalV = Tuple.Vector(0, 0, -1);
        var light = new PointLight(Tuple.Point(0, 10, -10), new Color(1, 1, 1));
        
        var result = Lighting.GetLighting(material, light, position, eyeV, normalV);
        Assert.Equal(new Color(1.6364, 1.6364, 1.6364), result);
    }

    // Scenario: Lighting with the light behind the surface
	// Given a vector (0, 0, -1) eyev
	// And a vector (0, 0, -1) normalv
	// And a point_light(point(0, 0, 10), color(1, 1, 1)) light
	// When the color result is lighting (m, light, position, eyev, normalv)
	// Then the color result is color(0.1, 0.1, 0.1)
    [Fact]
    public void Lighting_LightBehindSurface()
    {
        var material = new Material();
        var position = Tuple.Point(0,0,0);

        var eyeV = Tuple.Vector(0, 0, -1);
        var normalV = Tuple.Vector(0, 0, -1);
        var light = new PointLight(Tuple.Point(0, 0, 10), new Color(1, 1, 1));
        
        var result = Lighting.GetLighting(material, light, position, eyeV, normalV);
        Assert.Equal(new Color(0.1, 0.1, 0.1), result);
    }
}
