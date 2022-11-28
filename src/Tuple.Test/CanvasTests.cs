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
}
