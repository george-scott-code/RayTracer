using System;
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
        private readonly ColorsContext _lightsContext;

        private Canvas canvas { get; set; }
        
        private string PPM;

        public CanvasStepDefinitions(ScenarioContext scenarioContext, ColorsContext lightsContext)
        {
            _scenarioContext = scenarioContext;
            _lightsContext = lightsContext;
        }

        [Given(@"a canvas\((.*), (.*)\)")]
        public void GivenACanvas(int width, int height)
        {
            canvas = new Canvas(width, height);
        }

        [Given(@"a canvas\((.*), (.*)\) with every pixel set to color (.*)")]
        public void GivenACanvas(int width, int height, string colorName)
        {
            canvas = new Canvas(width, height, _lightsContext.Colors.GetValueOrDefault(colorName));
        }

        [Given(@"a color\((.*), (.*), (.*)\) (.*)")]
        public void GivenAColor(double red, double green, double blue, string name)
        {
            var c = new Color(red, green, blue);
            _lightsContext.Colors.Add(name, c);
        }

        [When(@"a (.*) pixel is written to \((.*), (.*)\)")]
        public void WhenWrite_PixelCRed(string colorName, int x, int y)
        {
            canvas.WritePixel(x, y, _lightsContext.Colors.GetValueOrDefault(colorName));
        }

        [When(@"the canvas is converted to ppm")]
        public void WhenTheCanvasIsConvertedToPpm()
        {
            this.PPM = canvas.ToPPM();
        }

        [Then(@"the width of the canvas is (.*)")]
        public void ThenC_Width(int p0)
        {
            Assert.Equal(p0, canvas.Width);
        }

        [Then(@"the height of the canvas is (.*)")]
        public void ThenC_Height(int p0)
        {
            Assert.Equal(p0, canvas.Height);
        }
        
        [Then(@"the pixel at \((.*), (.*)\) is color (.*)")]
        public void ThenPixelIsColor(int p0, int p1, string colorName)
        {
            Assert.True(canvas.Pixels[p0,p1].Equals(_lightsContext.Colors.GetValueOrDefault(colorName)));
        }

        [Then(@"every pixel of the canvas is color\((.*), (.*), (.*)\)")]
        public void ThenEveryPixelOfCIsColor(int p0, int p1, int p2)
        {
            var expectedColor = new Color(p0, p1, p2);

            for (int x = 0; x < canvas.Width; x++)
            {
                for (int y = 0; y < canvas.Height; y++)
                {
                    Color pixel = canvas.Pixels[x, y];
                    Assert.Equal(expectedColor, pixel);
                }
            }
        }

        [Then(@"line (.*) of the ppm is (.*)")]
        public void ThenLineOfThePPMIsContent(int lineNumber, string content)
        {
            var lines = this.PPM.Split(Environment.NewLine);
            var line = lines.Length >= lineNumber ? lines[lineNumber - 1] : null;

            Assert.Equal(content, line);
        }

        [Then("ppm ends with a newline character")]
        public void PpmEndsWithANewlineCharacter()
        {
            Assert.EndsWith(Environment.NewLine, this.PPM);
        }
    }
}
