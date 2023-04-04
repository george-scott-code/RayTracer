using System.Collections.Generic;
using TechTalk.SpecFlow;
using TupleLibrary;
using TupleLibrary.Extensions;
using Xunit;

namespace RayTracer.Tests.Steps
{
    [Binding]
    public sealed class TupleStepDefinitions
    {
       
        private readonly ScenarioContext _scenarioContext;
        private List<Tuple> tuples = new List<Tuple>();

        private Tuple result { get; set; }

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
            var tuple = Tuple.Point(x, y, z);
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

        [Then(@"a\.Magnitude is (.*)")]
        public void ThenMagnitudeV(double m)
        {
            Assert.True(tuples[0].Magnitude().DEquals(m));
        }

        [Then(@"dot\(a, b\) is (.*)")]
        public void ThenDotABIs(double product)
        {
            Assert.True(tuples[0].Dot(tuples[1]).DEquals(product));
        }

        [Then("a (.*) a point")]
        public void ThenTheResultShouldBePoint(string condition)
        {
            Assert.Equal(condition == "is", result.IsPoint);
        }

        [Then("a (.*) a vector")]
        public void ThenTheResultShouldBeVector(string condition)
        {
            Assert.Equal(condition == "is", result.IsVector);
        }

        [When(@"the result is a")]
        public void WhenTheResultIsA()
        {
           this.result = tuples[0];
        }

        [When(@"a(.*) is added to a(.*)")]
        public void WhenTupleIsAddedToTuple(int tupleNumber, int tupleNumber2)
        {
            this.result = tuples[tupleNumber -1].Add(tuples[tupleNumber2 -1]);
        }

        [When(@"a(.*) is subtracted from a(.*)")]
        public void WhenTupleIsSubtractedFromTuple(int subtrahend, int minuend)
        {
            this.result = tuples[minuend -1].Subtract(tuples[subtrahend -1]);
        }

        [When("the tuple is negated")]
        public void WhenTheTupleIsNegated()
        {
            this.result = -tuples[0];
        }

        [When(@"the tuple is normalized")]
        public void WhenTheTupleIsNormalized()
        {
            this.result = tuples[0].Normalize();
        }

        [When("the tuple is multiplied by (.*)")]
        public void WhenTheTupleIsMultipliedBy(double p0)
        {
            this.result = tuples[0] * p0;
        }

        [When(@"a is divided by (.*)")]
        public void WhenAIsDividedBy(double divisor)
        {
            this.result = tuples[0] / divisor;
        }

        [When(@"cross\(a, b\)")]
        public void WhenCrossAB()
        {
            result = tuples[0].Cross(tuples[1]);
        }

        [When(@"reflect\(a, b\)")]
        public void WhenReflectAB()
        {
            result = tuples[0].Reflect(tuples[1]);
        }

        [Then(@"the result is tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenTheResultIsTuple(double x, double y, double z, double w)
        {
            Tuple expected = new Tuple(x ,y, z, w);
            Assert.Equal(expected, result);
        }

        [Then(@"the result has a Magnitude of (.*)")]
        public void ThenTheResultHasAMagnitudeOf(int magnitude)
        {
            Assert.Equal(magnitude, result.Magnitude());
        }
    }
}
