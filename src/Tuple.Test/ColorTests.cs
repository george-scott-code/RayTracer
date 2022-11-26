using TupleLibrary;
using Xunit;

namespace TupleTests;

public class ColorTests
{
    [Fact]
    public void Colors_are_RGB_Tuples()
    {
        Color c = new Color(-0.5, 0.4, 1.7);

        Assert.Equal(-0.5, c.Red);
        Assert.Equal(0.4, c.Green);
        Assert.Equal(1.7, c.Blue);
    }
}
