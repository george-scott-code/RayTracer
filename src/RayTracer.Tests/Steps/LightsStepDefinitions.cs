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
        private readonly TransformationContext _transformationContext;

        public Color Result { get; private set; }

        public LightsStepDefinitions(ScenarioContext scenarioContext, ColorsContext colorsContext, TransformationContext transformationContext)
        {
            _scenarioContext = scenarioContext;
            _colorsContext = colorsContext;
            _transformationContext = transformationContext;
        }

        [Given(@"a material (.*)")]
        public void GivenAMaterial(string materialId)
        {
            var material = new Material();
            _colorsContext.Materials[materialId] = material;
        }

        [Given(@"a point_light \((.*), (.*)\) (.*)")]
        [When(@"a point_light \((.*), (.*)\) (.*)")]
        public void GivenAPoint_Light_With_PositionAndLight(string positionId, string intensityId, string pointLightId)
        {
            var position = _transformationContext.tuples[positionId];
            var color = _colorsContext.Colors[intensityId];
            var light = new PointLight(position, color);
            this._colorsContext.Lights[pointLightId] = light;
        }
        
        [When(@"the color result is lighting \((.*), (.*), (.*), (.*), (.*)\)")]
        public void WhenTheColorResultIsLightingMLightPositionEyevNormalv(string materialId, string pointLightId, string positionId, string eyeVector, string normalVector)
        {
            var material = _colorsContext.Materials[materialId];
            var light = this._colorsContext.Lights[pointLightId];
            var position = _transformationContext.tuples[positionId];
            var eyeV = _transformationContext.tuples[eyeVector];
            var normalV = _transformationContext.tuples[normalVector];
            
            this.Result = Lighting.GetLighting(material, light, position, eyeV, normalV);
        }

        [Then(@"light (.*) has position (.*)")]
        public void ThenLightLHasPositionP(string lightId, string positionId)
        {
            var light = this._colorsContext.Lights[lightId];
            Assert.Equal(_transformationContext.tuples[positionId], light.Position);
        }

        [Then(@"the color result is color\((.*), (.*), (.*)\)")]
        public void ThenTheResultIsColor(double red, double green, double blue)
        {
            Assert.True(this.Result.Equals(new Color(red, green, blue)));
        }

        [Then(@"light (.*) has intensity (.*)")]
        public void ThenLightIntensityIs(string lightId, string intensityId)
        {
            var light = this._colorsContext.Lights[lightId];
            Assert.Equal(_colorsContext.Colors[intensityId], light.Intensity);
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