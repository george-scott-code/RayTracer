using System.Collections.Generic;
using TechTalk.SpecFlow;
using TupleLibrary;
using Xunit;

namespace RayTracer.Tests.Steps
{
    [Binding]
    public sealed class CanvasStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private Canvas canvas { get; set; }
        private Dictionary<string, Color> Colors = new Dictionary<string, Color>();

        public CanvasStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a canvas\((.*), (.*)\)")]
        public void GivenACanvas(int width, int height)
        {
            canvas = new Canvas(width, height);
        }

        [Given(@"a color\((.*), (.*), (.*)\) (.*)")]
        public void GivenAColorRed(int red, int green, int blue, string name)
        {
            var c = new Color(red, green, blue);
            Colors.Add(name, c);
        }

        [When(@"write_pixel\(c, (.*), (.*), (.*)\)")]
        public void WhenWrite_PixelCRed(int x, int y, string colorName)
        {
            canvas.WritePixel(x, y, Colors.GetValueOrDefault(colorName));
        }

        [Then(@"c\.width = (.*)")]
        public void ThenC_Width(int p0)
        {
            Assert.Equal(p0, canvas.Width);
        }

        [Then(@"c\.height = (.*)")]
        public void ThenC_Height(int p0)
        {
            Assert.Equal(p0, canvas.Height);
        }
        
        [Then(@"pixel_at\(c, (.*), (.*)\) = (.*)")]
        public void ThenPixel_AtCRed(int p0, int p1, string colorName)
        {
            Assert.True(canvas.Pixels[p0,p1].Equals(Colors.GetValueOrDefault(colorName)));
        }

        [Then(@"every pixel of c is color\((.*), (.*), (.*)\)")]
        public void ThenEveryPixelOfCIsColor(int p0, int p1, int p2)
        {
            var expectedColor = new Color(p0, p1, p2);

            for(int x = 0; x < canvas.Width; x++)
            {
                for(int y = 0; y < canvas.Height; y++)
                {
                    Color pixel = canvas.Pixels[x, y];
                    Assert.Equal(expectedColor, pixel);
                }
            }
        }
    }
}
