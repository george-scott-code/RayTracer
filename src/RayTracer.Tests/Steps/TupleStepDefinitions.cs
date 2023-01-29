using System.Collections.Generic;
using TechTalk.SpecFlow;
using TupleLibrary;
using Xunit;

namespace RayTracer.Tests.Steps
{
    [Binding]
    public sealed class TupleStepDefinitions
    {
       
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private List<Tuple> tuples = new List<Tuple>();

        public TupleStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a tuple\((.*), (.*), (.*), (.*)\)")]
        public void GivenATuple(double x, double y, double z, double w)
        {
            var tuple = new Tuple(x, y, z, w);
            tuples.Add(tuple);
        }

        [Given(@"a point\((.*), (.*), (.*)\)")]
        public void GivenAPoint(double x, double y, double z)
        {
            var tuple = Tuple.Point(4.3, -4.2, 3.1);
            tuples.Add(tuple);
        }

        [Given(@"a vector\((.*), (.*), (.*)\)")]
        public void GivenAVector(double x, double y, double z)
        {
            var tuple = Tuple.Vector(x, y, z);
            tuples.Add(tuple);
        }

        [Then(@"a\.x = (.*)")]
        public void ThenA_X(double x)
        {
            Assert.Equal(x, tuples[0].X);
        }

        [Then(@"a\.y = (.*)")]
        public void ThenA_Y(double y)
        {
            Assert.Equal(y, tuples[0].Y);
        }

        [Then(@"a\.z = (.*)")]
        public void ThenA_Z(double z)
        {
            Assert.Equal(z, tuples[0].Z);
        }

        [Then(@"a\.w = (.*)")]
        public void ThenTheResultShouldBeW(double w)
        {
            Assert.Equal(w, tuples[0].W);
        }

        [Then("a (.*) a point")]
        public void ThenTheResultShouldBePoint(string condition)
        {
            Assert.Equal(condition == "is", tuples[0].IsPoint);
        }

        [Then("a (.*) a vector")]
        public void ThenTheResultShouldBeVector(string condition)
        {
            Assert.Equal(condition == "is", tuples[0].IsVector);
        }

        //split to When step
        [Then(@"a(.*) \+ a(.*) = tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenAddATuple(int tupleNumber, int tupleNumber2, int x, int y, int z, int w)
        {
            Tuple expected = new Tuple(x ,y, z, w);
            var result = tuples[tupleNumber -1].Add(tuples[tupleNumber2 -1]);
            Assert.Equal(expected, result);
        }
    }
}
