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

        [Given(@"a transform \((.*), (.*), (.*)\)")]
        public void GivenAPoint(double x, double y, double z)
        {
            throw new NotImplementedException();
        }

        [Given(@"a point\((.*), (.*), (.*)\) (.*)")]
        public void GivenAPoint(double x, double y, double z, string tupleIdentifier)
        {
            var tuple = TupleLibrary.Tuple.Point(x, y, z);
            tuples.Add(tupleIdentifier, tuple);
        }

        [When("point (.*) is multiplied by the transform")]
        public void WhenThepointIsMultipliedBy(string tupleIdentifier)
        {
            this.result = transform * tuples.GetValueOrDefault(tupleIdentifier);
        }

        [Then(@"the result is equal to point\((.*), (.*), (.*)\)")]
        public void ThenTheResultIsPoint(double x, double y, double z)
        {
            TupleLibrary.Tuple expected = new (x ,y, z, 0);
            Assert.Equal(expected, result);
        }
    }
}
