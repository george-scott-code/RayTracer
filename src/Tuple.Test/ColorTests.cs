using TupleLibrary;
using TupleLibrary.Extensions;
using Xunit;

namespace TupleTests;

public class ColorTests
{
    [Fact]
    public void Colors_are_RGB_tuples()
    {
        Color c = new Color(-0.5, 0.4, 1.7);

        Assert.Equal(-0.5, c.Red);
        Assert.Equal(0.4, c.Green);
        Assert.Equal(1.7, c.Blue);
    }

    [Fact]
    public void Adding_colors()
    {
        Color c1 = new Color(0.9, 0.6, 0.75);
        Color c2 = new Color(0.7, 0.1, 0.25);

        Color result = c1 + c2;

        Assert.Equal(1.6, result.Red);
        Assert.Equal(0.7, result.Green);
        Assert.Equal(1.0, result.Blue);
    }

    [Fact]
    public void Subtracting_colors()
    {
        Color c1 = new Color(0.9, 0.6, 0.75);
        Color c2 = new Color(0.7, 0.1, 0.25);

        Color result = c1 - c2;

        Assert.True(result.Red.DecimalEquals(0.2));
        Assert.True(result.Green.DecimalEquals(0.5));
        Assert.True(result.Blue.DecimalEquals(0.5));
    }
}
