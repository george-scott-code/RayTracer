using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TupleLibrary;
using Xunit;
using Tuple = TupleLibrary.Tuple;

namespace RayTracer.Tests.Steps
{
    [Binding]
    public sealed class RayStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private Dictionary<string, Intersection> Intersections = new();
        private Dictionary<string, Tuple> tuples = new Dictionary<string, Tuple>();
        private Dictionary<string, Tuple> vectors = new();
        private Dictionary<string, Ray> rays = new();
        private Dictionary<string, Sphere> spheres = new();

        private Exception exception;

        private double[] result;

        public RayStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        // TODO: refactor common steps and state
        [Given(@"an origin point \((.*), (.*), (.*)\) (.*)")]
        public void GivenAPoint(double x, double y, double z, string tupleIdentifier)
        {
            var tuple = TupleLibrary.Tuple.Point(x, y, z);
            tuples.Add(tupleIdentifier, tuple);
        }

        [Given(@"a direction vector \((.*), (.*), (.*)\) (.*)")]
        public void GivenAVector(double x, double y, double z, string tupleIdentifier)
        {
            var tuple = TupleLibrary.Tuple.Vector(x, y, z);
            tuples.Add(tupleIdentifier, tuple);
        }
        
        [Given(@"a ray \((.*), (.*)\) (.*)")]
        public void GivenARayOriginDirectionR(string tupleIdentifier, string directionIdentifier, string identifier)
        {
            var origin = tuples[tupleIdentifier];
            var direction = tuples[directionIdentifier];

            var ray = new Ray(origin, direction);
            this.rays[identifier] = ray;
        }

        [Given(@"a sphere (.*)")]
        public void GivenASphereS(string identifier)
        {
            this.spheres[identifier] = new Sphere();
        }

         [Given(@"an intersection \((.*), (.*)\) (.*)")]
         public void GivenAnIntersectionSI(Double t, string objectIdentifier, string identifier)
         {
            var obj = this.spheres[objectIdentifier];
            this.Intersections[identifier] = (new Intersection(t, obj));
         }

        [When(@"the intersection (.*) is calculated for sphere (.*) and ray (.*)")]
        public void WhenTheIntersectionXsIsCalculatedForSphereSAndRayR(string identifier, string sphereIdentifier, string rayIdentifier)
        {
            var sphere = this.spheres[sphereIdentifier];
            var ray = this.rays[rayIdentifier];

            result = sphere.Intersection(ray);
        }
        
        [Then(@"the origin of ray (.*) is equal to point (.*)")]
        public void ThenTheOriginOfRayRIsEqualToPointOrigin(string rayIdentifier, string originIdentifier)
        {
            var ray = this.rays[rayIdentifier];
            var expectedOrigin = this.tuples[originIdentifier];
            Assert.Equal(expectedOrigin, ray.Origin);
        }

        [Then(@"the direction of ray (.*) is equal to vector (.*)")]
        public void ThenTheDirectionOfRayRIsEqualToVectorDirection(string rayIdentifier, string directionIdentifier)
        {
            var ray = this.rays[rayIdentifier];
            var expectedDirection = this.tuples[directionIdentifier];
            Assert.Equal(expectedDirection, ray.Direction);
        }

        [Then(@"the result of the intersection has count (.*)")]
        public void ThenTheResultOfTheIntersectionHasCount(int intersectionCount)
        {
            Assert.Equal(intersectionCount, result.Length);
        }

        [Then(@"the result of the intersection index (.*) = (.*)")]
        public void ThenTheResultOfTheIntersectionIndex(int intersectionIndex, double intersectionValue)
        {
            Assert.Equal(intersectionValue, result[intersectionIndex]);
        }

        [When(@"the position (.*) of ray (.*) is calculated for t = (.*)")]
        public void ThenPositionRPPoint(string positionIdentifier, string rayIdentifier, double t)
        {
            var ray = this.rays[rayIdentifier];
            var position = ray.Position(t);
            tuples[positionIdentifier] = position;
        }

        [Then(@"position (.*) is equal to point \((.*), (.*), (.*)\)")]
        public void ThenPositionPIsEqualToPoint(string positionIdentifier, double x, double y, double z)
        {
            var position = this.tuples[positionIdentifier];
            var expectedPoint = Tuple.Point(x, y, z);
            Assert.Equal(expectedPoint, position);
        }

        [Then(@"intersection (.*) has property t = (.*)")]
        public void ThenI_T(string identifier, Double expectedT)
        {
            var intersection = this.Intersections[identifier];
            Assert.Equal(expectedT, intersection.T);
        }

        [Then(@"intersection (.*) has property obj = (.*)")]
        public void ThenI_Obj(string identifier, string expectedObj)
        {
            var intersection = this.Intersections[identifier];
            var expected = this.spheres[expectedObj];
            Assert.Equal(expected, intersection.Obj);
        }
    }
}
