using System;
using TupleLibrary.Extensions;
using Xunit;

namespace TupleLibrary;

public class CameraTests
{
    // Scenario: Constructing a camera
    // Given hsize ← 160
    // And vsize ← 120
    // And field_of_view ← π/2
    // When c ← camera(hsize, vsize, field_of_view)
    // Then c.hsize = 160
    // And c.vsize = 120
    // And c.field_of_view = π/2
    // And c.transform = identity_matrix
    [Fact]
    public void ConstructingACamera()
    {
        var hSize = 160;
        var vSize = 120;
        var fieldOfView = Math.PI / 2;
        var c = new Camera(hSize, vSize, fieldOfView);

        Assert.Equal(hSize, c.HSize);
        Assert.Equal(vSize, c.VSize);
        Assert.Equal(fieldOfView, c.FieldOfView);
        Assert.Equal(Matrix.Identity(), c.Transform);
    }

    // Scenario: The pixel size for a horizontal canvas
    // Given c ← camera(200, 125, π/2)
    // Then c.pixel_size = 0.01
    [Fact]
    public void HorizontalCanvasPixelSize()
    {
        var c = new Camera(200, 125, Math.PI/2);
        Assert.True(c.PixelSize.DEquals(0.01));
    }

    // Scenario: The pixel size for a vertical canvas
    // Given c ← camera(125, 200, π/2)
    // Then c.pixel_size = 0.01
    [Fact]
    public void VerticalCanvasPixelSize()
    {
        var c = new Camera(125, 200, Math.PI/2);
        Assert.True(c.PixelSize.DEquals(0.01));
    }

    // Scenario: Constructing a ray through the center of the canvas
    // Given c ← camera(201, 101, π/2)
    // When r ← ray_for_pixel(c, 100, 50)
    // Then r.origin = point(0, 0, 0)
    // And r.direction = vector(0, 0, -1)
    [Fact]
    public void ConstructingRayCanvasCenter()
    {
        var c = new Camera(201, 101, Math.PI/2);
        var r = c.RayForPixel(100, 50);
        Assert.Equal(r.Origin, Tuple.Point(0, 0, 0));
        Assert.Equal(r.Direction, Tuple.Vector(0, 0, -1));
    }

    // Scenario: Constructing a ray through a corner of the canvas
    // Given c ← camera(201, 101, π/2)
    // When r ← ray_for_pixel(c, 0, 0)
    // Then r.origin = point(0, 0, 0)
    // And r.direction = vector(0.66519, 0.33259, -0.66851)
    [Fact]
    public void ConstructingRayCanvasCorner()
    {
        var c = new Camera(201, 101, Math.PI/2);
        var r = c.RayForPixel(0, 0);
        Assert.Equal(r.Origin, Tuple.Point(0, 0, 0));
        Assert.Equal(r.Direction, Tuple.Vector(0.66519, 0.33259, -0.66851));
    }

    // Scenario: Constructing a ray when the camera is transformed
    // Given c ← camera(201, 101, π/2)
    // When c.transform ← rotation_y(π/4) * translation(0, -2, 5)
    // And r ← ray_for_pixel(c, 100, 50)
    // Then r.origin = point(0, 2, -5)
    // And r.direction = vector(√2/2, 0, -√2/2)
    [Fact]
    public void ConstructingRayCameraTransformed()
    {
        var c = new Camera(201, 101, Math.PI / 2)
        {
            Transform = Matrix.RotationY(Math.PI / 4) * Matrix.Translation(0, -2, 5)
        };
        var r = c.RayForPixel(100, 50);
        Assert.Equal(r.Origin, Tuple.Point(0, 2, -5));

        var expectedDirection = Tuple.Vector(0.70710678118, 0, -0.70710678118);
        Assert.True(expectedDirection.X.DEquals(r.Direction.X));
        Assert.True(expectedDirection.Y.DEquals(r.Direction.Y));
        Assert.True(expectedDirection.Z.DEquals(r.Direction.Z));
    }

    // Scenario: Rendering a world with a camera
    // Given w ← default_world()
    // And c ← camera(11, 11, π/2)
    // And from ← point(0, 0, -5)
    // And to ← point(0, 0, 0)
    // And up ← vector(0, 1, 0)
    // And c.transform ← view_transform(from, to, up)
    // When image ← render(c, w)
    // Then pixel_at(image, 5, 5) = color(0.38066, 0.47583, 0.2855)
    [Fact]
    public void RenderingWorldWithCamera()
    {
        var w = World.GetDefaultWorld();
        var from = Tuple.Point(0, 0, -5);
        var to = Tuple.Point(0, 0, 0);
        var up = Tuple.Vector(0, 1, 0);
        var c = new Camera(11, 11, Math.PI / 2)
        {
            Transform = Matrix.ViewTransform(from, to, up)
        };

        var image = c.Render(w);
        var pixel = image.Pixels[5,5];
        Assert.Equal(new Color(0.38066, 0.47583, 0.2855), pixel);
    }
}