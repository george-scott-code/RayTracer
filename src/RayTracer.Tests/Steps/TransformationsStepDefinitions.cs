using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TupleLibrary;
using TupleLibrary.Extensions;
using Xunit;

namespace RayTracer.Tests.Steps
{
    [Binding]
    public sealed class TransformationsStepDefinitions
    {
       
        private readonly ScenarioContext _scenarioContext;
        private readonly TransformationContext _transformationContext;

        public TransformationsStepDefinitions(ScenarioContext scenarioContext, TransformationContext transformationContext)
        {
            _scenarioContext = scenarioContext;
            _transformationContext = transformationContext;
        }

        [Given(@"a translation \((.*), (.*), (.*)\) (.*)")]
        public void GivenATranslation(double x, double y, double z, string identifier)
        {
            _transformationContext.Transforms[identifier] = Matrix.Translation(x, y, z);
        }

        [Given(@"a scaling \((.*), (.*), (.*)\) (.*)")]
        public void GivenAScaling(double x, double y, double z, string identifier)
        {
            _transformationContext.Transforms[identifier] = Matrix.Scaling(x, y, z);
        }

        [Given(@"a rotation_x \(π / (.*)\) (.*)")]
        public void GivenAnXRotation(int divisor, string identifier)
        {
            var radians = Math.PI / divisor;
            _transformationContext.Transforms.Add(identifier, Matrix.RotationX(radians));
        }

        [Given(@"a rotation_y \(π / (.*)\) (.*)")]
        public void GivenAnYRotation(int divisor, string identifier)
        {
            var radians = Math.PI / divisor;
            _transformationContext.Transforms.Add(identifier, Matrix.RotationY(radians));
        }

        [Given(@"a rotation_z \(π / (.*)\) (.*)")]
        public void GivenAnZRotation(int divisor, string identifier)
        {
            var radians = Math.PI / divisor;
            _transformationContext.Transforms.Add(identifier, Matrix.RotationZ(radians));
        }

        [Given(@"a shearing \((.*), (.*), (.*), (.*), (.*), (.*)\) (.*)")]
        public void GivenA_Shearing(int p0, int p1, int p2, int p3, int p4, int p5, string identifier)
        {
            _transformationContext.Transforms[identifier] = Matrix.Shearing(p0, p1, p2, p3, p4, p5);
        }
        
        [Given(@"a point \((.*), (.*), (.*)\) (.*)")]
        public void GivenAPoint(double x, double y, double z, string tupleIdentifier)
        {
            var tuple = TupleLibrary.Tuple.Point(x, y, z);
            _transformationContext.tuples.Add(tupleIdentifier, tuple);
        }

        [Given(@"a vector \((.*), (.*), (.*)\) (.*)")]
        public void GivenAVector(double x, double y, double z, string tupleIdentifier)
        {
            var tuple = TupleLibrary.Tuple.Vector(x, y, z);
            _transformationContext.tuples.Add(tupleIdentifier, tuple);
        }

        [Given(@"transform (.*) = transform (.*) \* (.*) \* (.*)")]
         public void GivenAChainOfThreeTrasnforms(string transformName, string transformA, string transformB, string transformC)
         {
             var result = _transformationContext.Transforms[transformA] * _transformationContext.Transforms[transformB] * _transformationContext.Transforms[transformC];
             _transformationContext.Transforms[transformName] = result;
         }

        [When("(point|vector) (.*) is multiplied by the transform (.*)")]
        public void WhenThepointIsMultipliedByX(string tupleType, string tupleIdentifier, string transformIdentifier)
        {
            var transformX = _transformationContext.Transforms.GetValueOrDefault(transformIdentifier);
            _transformationContext.tuples["result"] = transformX * _transformationContext.tuples.GetValueOrDefault(tupleIdentifier);
        }

        [When(@"the inverse of the transform (.*) is calculated")]
        public void WhenTheInverseOfTheTransformXIsCalculated(string identifier)
        {
            _transformationContext.Transforms[identifier] = _transformationContext.Transforms[identifier].Inverse();
        }

        [Then(@"the result is equal to point \((.*), (.*), (.*)\)")]
        public void ThenTheResultIsPoint(double x, double y, double z)
        {
            TupleLibrary.Tuple expected = new (x ,y, z, 1);
            Assert.Equal(expected, _transformationContext.tuples["result"]);
        }

        [Then(@"the result is equal to vector \((.*), (.*), (.*)\)")]
        public void ThenTheResultIsVector(double x, double y, double z)
        {
            TupleLibrary.Tuple expected = new (x ,y, z, 0);
            Assert.Equal(expected, _transformationContext.tuples["result"]);
        }
    }
}
