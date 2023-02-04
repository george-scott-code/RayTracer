using System.Collections.Generic;
using TechTalk.SpecFlow;
using TupleLibrary;
using TupleLibrary.Extensions;
using Xunit;

namespace RayTracer.Tests.Steps
{
    [Binding]
    public sealed class ColorStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private List<Color> colors = new List<Color>();

        private Color result { get; set; }

        public ColorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a color\((.*), (.*), (.*)\)")]
        public void GivenAColor(double red, double greeen, double blue)
        {
            var color = new Color(red, greeen, blue);
            colors.Add(color);
        }

        [Then(@"c\.red = (.*)")]
        public void ThenA_Red(double expected)
        {
            Assert.Equal(expected, colors[0].Red);
        }

        [Then(@"c\.green = (.*)")]
        public void ThenA_Green(double expected)
        {
            Assert.Equal(expected, colors[0].Green);
        }

        [Then(@"c\.blue = (.*)")]
        public void ThenA_Blue(double expected)
        {
            Assert.Equal(expected, colors[0].Blue);
        }

        [When(@"c(.*) is added to c(.*)")]
        public void WhenAColorIsAddedToAnotherColor(int colorNumber, int colorNumber2)
        {
            this.result = colors[colorNumber -1] + colors[colorNumber2 -1];
        }

        [When(@"c(.*) is subtracted from c(.*)")]
        public void WhenAColorIsSubtractedFromAnotherColor(int colorNumber, int colorNumber2)
        {
            this.result = colors[colorNumber2 -1] - colors[colorNumber -1];
        }

        [When(@"c(.*) is multiplied by c(.*)")]
        public void WhenAColorIsMultipliedByAnotherColor(int colorNumber, int colorNumber2)
        {
            this.result = colors[colorNumber -1] * colors[colorNumber2 -1];
        }

        [When(@"c is multiplied by (.*)")]
        public void WhenAColorIsMultipliedBy(int p0)
        {
            this.result = colors[0] * p0;
        }

        [Then(@"the result is color\((.*), (.*), (.*)\)")]
        public void ThenTheResultIsColor(double red, double green, double blue)
        {
            Assert.True(this.result.Equals(new Color(red, green, blue)));
        }
    }
}
