using System.IO;
using TupleLibrary;
using Xunit;

namespace TupleTests;

public class CanvasTests
{
    [Fact]
    public void Creating_a_canvas()
    {
        Color black = new Color(0,0,0);
        var c = new Canvas(10, 20);

        Assert.Equal(10, c.Width);
        Assert.Equal(20, c.Height);

        for(int x = 0; x < c.Width; x++)
        {
            for(int y = 0; y < c.Height; y++)
            {
                Color pixel = c.Pixels[x, y];
                Assert.True(pixel.Equals(black));
            }
        }
    }

    [Fact]
    public void Writing_pixels_to_a_canvas()
    { 
        var c = new Canvas(10, 20);
        var red = new Color(1,0,0);

        c.WritePixel(2, 3, red);    

        Assert.True(c.Pixels[2,3].Equals(red));
    }

    [Fact]
    public void Constructing_the_PPM_header()
    {
        // Given
        Canvas c = new Canvas(5, 3);
        // When
        string ppm = c.ToPPM();
        // Then
        using var reader = new StringReader(ppm);
        string firstLine = reader.ReadLine();
        string secondLine = reader.ReadLine();
        string thirdLine = reader.ReadLine();

        Assert.Equal("P3", firstLine);
        Assert.Equal("5 3", secondLine);
        Assert.Equal("255", thirdLine);
    }
}