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
        private Dictionary<string, Intersection[]> Intersections = new();
        private Dictionary<string, Tuple> tuples = new Dictionary<string, Tuple>();
        private Dictionary<string, Tuple> vectors = new();
        private Dictionary<string, Ray> rays = new();
        private Dictionary<string, Sphere> spheres = new();

        private Exception exception;

        public Intersection Hits { get; private set; }

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

        [Given(@"an intersection\((.*), (.*)\) (.*)")]
        public void GivenAAnIntersection(double p0, string objIdentifier, string identifier)
        {
            var obj = spheres[objIdentifier];
            Intersections[identifier] = new Intersection[] {new Intersection(p0, obj)};
        }

        //TODO: varied length array of params
        [Given(@"intersections\((.*), (.*)\) (.*)")]
        public void GivenIntersections(string p0, string p1, string intersectionId)
        {
            Intersections[intersectionId] = new Intersection[] {Intersections[p0][0], Intersections[p1][0] };
        }

        [Given(@"multiple intersections\((.*), (.*), (.*), (.*)\) (.*)")]
        public void GivenMultipleIntersections(string p0, string p1, string p2, string p4, string intersectionId)
        {
            Intersections[intersectionId] = new Intersection[] {Intersections[p0][0], Intersections[p1][0], Intersections[p2][0], Intersections[p4][0] };
        }

        [When(@"the intersection (.*) is calculated for sphere (.*) and ray (.*)")]
        public void WhenTheIntersectionXsIsCalculatedForSphereSAndRayR(string identifier, string sphereIdentifier, string rayIdentifier)
        {
            var sphere = this.spheres[sphereIdentifier];
            var ray = this.rays[rayIdentifier];

            Intersections[identifier] = sphere.Intersection(ray);
        }

        [When(@"the hit is calculated for intersections (.*)")]
        public void WhenTheHitIsCalculatedForIntersectionsXs(string intersectionIdentifier)
        {
            this.Hits = Intersections[intersectionIdentifier].Hit();
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

        [Then(@"the intersection (.*) has count (.*)")]
        public void ThenTheResultOfTheIntersectionHasCount(string identifier, int intersectionCount)
        {
            var intersection = this.Intersections[identifier];
            Assert.Equal(intersectionCount, intersection.Length);
        }

        [Then(@"the intersection (.*) index (.*) = (.*)")]
        public void ThenTheResultOfTheIntersectionIndex(string identifier, int intersectionIndex, double intersectionValue)
        {
            var intersection = this.Intersections[identifier][intersectionIndex];
            Assert.Equal(intersectionValue, intersection.T);
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

        [Then(@"intersection (.*) index (.*) has property obj = (.*)")]
        public void ThenI_Obj(string identifier,int index, string expectedObj)
        {
            var intersection = this.Intersections[identifier][index];
            var expected = this.spheres[expectedObj];
            Assert.Equal(expected, intersection.Obj);
        }

        [Then(@"the hit is equal to intersection (.*)")]
        public void ThenHitIsEqualToIntersectionI(string identifier)
        {
            var intersection = this.Intersections[identifier];
            Assert.Equal(intersection[0], this.Hits);
        }

        [Then(@"the hit is nothing")]
        public void ThenTheHitIsNothing()
        {
            Assert.Equal(null, this.Hits);
        }
    }
}
