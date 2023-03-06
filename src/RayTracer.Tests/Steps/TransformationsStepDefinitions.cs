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
        private Dictionary<string, TupleLibrary.Tuple> tuples = new();

        private TupleLibrary.Tuple result { get; set; }
        private Matrix transform {get; set;}
        private Dictionary<string, Matrix> transforms = new();

        public TransformationsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a translation \((.*), (.*), (.*)\)")]
        public void GivenATranslation(double x, double y, double z)
        {
            this.transform = Matrix.Translation(x, y, z);
        }

        [Given(@"a scaling \((.*), (.*), (.*)\)")]
        public void GivenAScaling(double x, double y, double z)
        {
            this.transform = Matrix.Scaling(x, y, z);
        }

        [Given(@"a rotation_x \(π / (.*)\) (.*)")]
        public void GivenAnXRotation(int divisor, string identifier)
        {
            var radians = Math.PI / divisor;
            transforms.Add(identifier, Matrix.RotationX(radians));
        }

        [Given(@"a rotation_y \(π / (.*)\) (.*)")]
        public void GivenAnYRotation(int divisor, string identifier)
        {
            var radians = Math.PI / divisor;
            transforms.Add(identifier, Matrix.RotationY(radians));
        }

        [Given(@"a rotation_z \(π / (.*)\) (.*)")]
        public void GivenAnZRotation(int divisor, string identifier)
        {
            var radians = Math.PI / divisor;
            transforms.Add(identifier, Matrix.RotationZ(radians));
        }

        [Given(@"a shearing \((.*), (.*), (.*), (.*), (.*), (.*)\) (.*)")]
        public void GivenAnshearing(int p0, int p1, int p2, int p3, int p4, int p5, string identifier)
        {
            this.transform = Matrix.Shearing(p0, p1, p2, p3, p4, p5);
        }

        [Given(@"a point \((.*), (.*), (.*)\) (.*)")]
        public void GivenAPoint(double x, double y, double z, string tupleIdentifier)
        {
            var tuple = TupleLibrary.Tuple.Point(x, y, z);
            tuples.Add(tupleIdentifier, tuple);
        }

        [Given(@"a vector \((.*), (.*), (.*)\) (.*)")]
        public void GivenAVector(double x, double y, double z, string tupleIdentifier)
        {
            var tuple = TupleLibrary.Tuple.Vector(x, y, z);
            tuples.Add(tupleIdentifier, tuple);
        }

        [When("(point|vector) (.*) is multiplied by the transform")]
        public void WhenThepointIsMultipliedBy(string tupleType, string tupleIdentifier)
        {
            this.result = transform * tuples.GetValueOrDefault(tupleIdentifier);
        }

        [When("(point|vector) (.*) is multiplied by the transform (.*)")]
        public void WhenThepointIsMultipliedByX(string tupleType, string tupleIdentifier, string transformIdentifier)
        {
            var transformX = transforms.GetValueOrDefault(transformIdentifier);
            this.result = transformX * tuples.GetValueOrDefault(tupleIdentifier);
        }

        [When(@"the inverse of the transform is calculated")]
        public void WhenTheInverseOfTheTransformIsCalculated()
        {
            this.transform = this.transform.Inverse();
        }

        [When(@"the inverse of the transform (.*) is calculated")]
        public void WhenTheInverseOfTheTransformXIsCalculated(string identifier)
        {
            var transformX = transforms.GetValueOrDefault(identifier);
            transforms[identifier] = transformX.Inverse();
        }

        [Then(@"the result is equal to point \((.*), (.*), (.*)\)")]
        public void ThenTheResultIsPoint(double x, double y, double z)
        {
            TupleLibrary.Tuple expected = new (x ,y, z, 1);
            Assert.Equal(expected, result);
        }

        [Then(@"the result is equal to vector \((.*), (.*), (.*)\)")]
        public void ThenTheResultIsVector(double x, double y, double z)
        {
            TupleLibrary.Tuple expected = new (x ,y, z, 0);
            Assert.Equal(expected, result);
        }
    }
}
