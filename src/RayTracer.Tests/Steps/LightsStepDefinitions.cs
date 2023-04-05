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

        [Given(@"a material (.*)")]
        public void GivenAMaterial(string materialId)
        {
            var material = new Material();
            _colorsContext.Materials[materialId] = material;
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

        [Then(@"the material (.*) has color (.*)")]
        public void ThenTheMaterialHasColor(string materialId, string colorId)
        {
            var material = _colorsContext.Materials[materialId];
            var color = _colorsContext.Colors[colorId];
            Assert.Equal(color, material.Color);
        }

        [Then(@"the material (.*) has ambient (.*)")]
        public void ThenTheMaterialHasAmbient(string materialId, double ambientValue)
        {
            var material = _colorsContext.Materials[materialId];
            Assert.Equal(ambientValue, material.Ambient);
        }

        [Then(@"the material (.*) has diffuse (.*)")]
        public void ThenTheMaterialHasDiffuse(string materialId, double value)
        {
            var material = _colorsContext.Materials[materialId];
            Assert.Equal(value, material.Diffuse);
        }

        [Then(@"the material (.*) has specular (.*)")]
        public void ThenTheMaterialHasSpecular(string materialId, double value)
        {
            var material = _colorsContext.Materials[materialId];
            Assert.Equal(value, material.Specular);
        }
        
        [Then(@"the material (.*) has shininess (.*)")]
        public void ThenTheMaterialHasShininess(string materialId, double value)
        {
            var material = _colorsContext.Materials[materialId];
            Assert.Equal(value, material.Shininess);
        }
    }
}
