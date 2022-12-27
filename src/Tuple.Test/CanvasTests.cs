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
        Canvas c = new Canvas(5, 3);

        string ppm = c.ToPPM();

        using var reader = new StringReader(ppm);
        string firstLine = reader.ReadLine();
        string secondLine = reader.ReadLine();
        string thirdLine = reader.ReadLine();

        Assert.Equal("P3", firstLine);
        Assert.Equal("5 3", secondLine);
        Assert.Equal("255", thirdLine);
    }

    [Fact]
    public void Constructing_the_PPM_pixel_data()
    {
        Canvas c = new Canvas(5, 3);
        var c1 = new Color(1.5,0,0);
        var c2 = new Color(0, 0.5, 0);
        var c3 = new Color(-0.6, 0, 1);


        c.WritePixel(0, 0, c1);
        c.WritePixel(2, 1, c2);
        c.WritePixel(4, 2, c3);

        string ppm = c.ToPPM();

        using var reader = new StringReader(ppm);
        _ = reader.ReadLine();
        _ = reader.ReadLine();
        _ = reader.ReadLine();
        string line4 = reader.ReadLine();
        string line5 = reader.ReadLine();
        string line6 = reader.ReadLine();

        // the RGB representation is normalized with a 'magnitude?' of 255?
        Assert.Equal("255 0 0 0 0 0 0 0 0 0 0 0 0 0 0", line4);
        Assert.Equal("0 0 0 0 0 0 0 128 0 0 0 0 0 0 0", line5);
        Assert.Equal("0 0 0 0 0 0 0 0 0 0 0 0 0 0 255", line6);
    }
}