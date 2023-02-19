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
        private Dictionary<string, TupleLibrary.Tuple> tuples = new ();

        private TupleLibrary.Tuple result { get; set; }
        private Matrix transform {get; set;}

        public TransformationsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a translation \((.*), (.*), (.*)\)")]
        public void GivenAtranslation(double x, double y, double z)
        {
            this.transform = Matrix.Translation(x, y, z);
        }

        [Given(@"a point\((.*), (.*), (.*)\) (.*)")]
        public void GivenAPoint(double x, double y, double z, string tupleIdentifier)
        {
            var tuple = TupleLibrary.Tuple.Point(x, y, z);
            tuples.Add(tupleIdentifier, tuple);
        }

        [Given(@"a vector\((.*), (.*), (.*)\) (.*)")]
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

        [When(@"the inverse of the transform is calculated")]
        public void WhenTheInverseOfTheTransformIsCalculated()
        {
            this.transform = this.transform.Inverse();
        }

        [Then(@"the result is equal to point\((.*), (.*), (.*)\)")]
        public void ThenTheResultIsPoint(double x, double y, double z)
        {
            TupleLibrary.Tuple expected = new (x ,y, z, 1);
            Assert.Equal(expected, result);
        }

        [Then(@"the result is equal to vector\((.*), (.*), (.*)\)")]
        public void ThenTheResultIsVector(double x, double y, double z)
        {
            TupleLibrary.Tuple expected = new (x ,y, z, 0);
            Assert.Equal(expected, result);
        }
    }
}
