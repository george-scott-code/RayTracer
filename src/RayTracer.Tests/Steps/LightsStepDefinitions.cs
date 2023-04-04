using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TupleLibrary;
using Xunit;

namespace RayTracer.Tests.Steps
{
    [Binding]
    public sealed class LightsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ColorsContext _colorsContext;
        private TupleLibrary.Tuple position;
        private PointLight light;

        public LightsStepDefinitions(ScenarioContext scenarioContext, ColorsContext colorsContext)
        {
            _scenarioContext = scenarioContext;
            _colorsContext = colorsContext;
        }

        [Given(@"position = point\((.*), (.*), (.*)\)")]
        public void GivenPositionIs(float x, float y, float z)
        {
            position = TupleLibrary.Tuple.Point(x, y, z);
        }

        [When(@"light = point_light\(position, intensity\)")]
        public void WhenLightIsCreated()
        {
            light = new PointLight(position, _colorsContext.Colors["intensity"]);
        }

        [Then(@"light.position = position")]
        public void ThenLightPositionIs()
        {
            Assert.Equal(position, light.Position);
        }

        [Then(@"light.intensity = intensity")]
        public void ThenLightIntensityIs()
        {
            Assert.Equal(_colorsContext.Colors["intensity"], light.Intensity);
        }
    }
}
