using TechTalk.SpecFlow;

namespace RayTracer.Tests.Steps
{
    [Binding]
    public sealed class TupleStepDefinitions
    {
       
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public TupleStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("a ← tuple((.*), (.*), (.*), (.*))")]
        public void GivenATuple(double x, double y, double z, double w)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _scenarioContext.Pending();
        }

        [Then(@"a\.x = (.*)")]
        public void ThenA_X(double p0)
        {
            _scenarioContext.Pending();
        }

        [Then(@"a\.y = (.*)")]
        public void ThenA_Y(double p0)
        {
            _scenarioContext.Pending();
        }

        [Then(@"a\.z = (.*)")]
        public void ThenA_Z(double p0)
        {
            _scenarioContext.Pending();
        }

        [Then(@"a\.w = (.*)")]
        public void ThenTheResultShouldBeW(double result)
        {
            _scenarioContext.Pending();
        }

        [Then("a (.*) a point")]
        public void ThenTheResultShouldBePoint(string condition)
        {
            _scenarioContext.Pending();
        }

        [Then("a (.*) a vector")]
        public void ThenTheResultShouldBeVector(string condition)
        {
            _scenarioContext.Pending();
        }
    }
}
