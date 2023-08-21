using System;
using TupleLibrary.Extensions;
using Xunit;

namespace TupleLibrary;

public class CameraTests
{
    public CameraTests()
    {
        
    }

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
        Assert.True(0.01.DEquals(c.PixelSize));
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
}