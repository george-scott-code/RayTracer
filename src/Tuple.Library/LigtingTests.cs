using Xunit;

namespace TupleLibrary;

public class LigtingTests
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
}
