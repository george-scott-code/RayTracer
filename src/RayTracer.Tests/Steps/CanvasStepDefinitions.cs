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
        private List<Color> colors = new List<Color>();

        private Canvas canvas { get; set; }

        public CanvasStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a canvas\((.*), (.*)\)")]
        public void GivenACanvas(int width, int height)
        {
            canvas = new Canvas(width, height);
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
