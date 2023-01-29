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
        private Tuple tuple = null;

        public TupleStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        // [Given("a ← tuple((.*), (.*), (.*), (.*))")]
        // public void GivenATuple(double x, double y, double z, double w)
        // {
        //     this.tuple = new Tuple(x, y, z, w);
        //     // _scenarioContext.Pending();
        // }
        [Given(@"a tuple\((.*), (.*), (.*), (.*)\)")]
        public void GivenATuple(double x, double y, double z, double w)
        {
            this.tuple = new Tuple(x, y, z, w);
        }

        [Then(@"a\.x = (.*)")]
        public void ThenA_X(double x)
        {
            Assert.Equal(x, tuple.X);
            // _scenarioContext.Pending();
        }

        [Then(@"a\.y = (.*)")]
        public void ThenA_Y(double y)
        {
            Assert.Equal(y, tuple.Y);
            // _scenarioContext.Pending();
        }

        [Then(@"a\.z = (.*)")]
        public void ThenA_Z(double z)
        {
            Assert.Equal(z, tuple.Z);
        }

        [Then(@"a\.w = (.*)")]
        public void ThenTheResultShouldBeW(double w)
        {
            Assert.Equal(w, tuple.W);
        }

        [Then("a (.*) a point")]
        public void ThenTheResultShouldBePoint(string condition)
        {
            Assert.Equal(condition == "is", tuple.IsPoint);
        }

        [Then("a (.*) a vector")]
        public void ThenTheResultShouldBeVector(string condition)
        {
            Assert.Equal(condition == "is", tuple.IsVector);
        }
    }
}
