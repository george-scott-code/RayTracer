using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly TransformationContext _transformationContext;
        private readonly MatricesContext _matricesContext;
        private readonly ColorsContext _colorsContext;
        private Dictionary<string, Intersection[]> Intersections = new();
        private Dictionary<string, Tuple> vectors = new();
        private Dictionary<string, Ray> rays = new();
        private Dictionary<string, Sphere> spheres = new();

        public Intersection Hits { get; private set; }

        public RayStepDefinitions(ScenarioContext scenarioContext, TransformationContext transformationContext, MatricesContext matricesContext, ColorsContext colorsContext)
        {
            _scenarioContext = scenarioContext;
            _transformationContext = transformationContext;
            _matricesContext = matricesContext;
            _colorsContext = colorsContext;
        }

        [Given(@"a direction vector \((.*), (.*), (.*)\) (.*)")]
        public void GivenAVector(double x, double y, double z, string tupleIdentifier)
        {
            var tuple = TupleLibrary.Tuple.Vector(x, y, z);
            _transformationContext.tuples.Add(tupleIdentifier, tuple);
        }
        
        [Given(@"a ray \((.*), (.*)\) (.*)")]
        public void GivenARayOriginDirectionR(string tupleIdentifier, string directionIdentifier, string identifier)
        {
            var origin = _transformationContext.tuples[tupleIdentifier];
            var direction = _transformationContext.tuples[directionIdentifier];

            var ray = new Ray(origin, direction);
            this.rays[identifier] = ray;
        }

        [Given(@"a sphere (.*)")]
        public void GivenASphereS(string identifier)
        {
            this.spheres[identifier] = new Sphere();
        }

        [Given(@"a sphere (.*) with:")]
        public void GivenShpereWith(string sphereId, Table table)
        {
            var sphere = new Sphere();

            var parameters = table.Rows
              .Select(row => new { Param = row[0], Value = row[1]});

            foreach (var param in parameters)
            {
                switch (param.Param)
                {
                    case "transform":
                        var parts = param.Value.Split(' ');
                        if(parts[0] == "scaling")
                        {
                            //scaling (0.5, 0.5, 0.5)
                            var xyzString = parts[1].Substring(1, param.Value.Length - 2);
                            var xyz = xyzString.Split(',', StringSplitOptions.TrimEntries).Select(x => double.Parse(x));
                            sphere.Transform = Matrix.Scaling(xyz.First(), xyz.Skip(1).First(), xyz.Skip(2).First());
                        }
                        break;
                }
            }
            this.spheres[sphereId] = new Sphere();
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

        [When(@"ray (.*) is multiplied by the transform (.*)")]
        public void WhenRayRIsMultipliedByTheTransformT(string rayIdentifier, string transformIdentifier)
        {
            var ray = this.rays[rayIdentifier];
            var transform = _transformationContext.Transforms[transformIdentifier];
            rays["result"] = transform * ray;
        }
        
        [Then(@"the origin of ray (.*) is equal to point (.*)")]
        public void ThenTheOriginOfRayRIsEqualToPointOrigin(string rayIdentifier, string originIdentifier)
        {
            var ray = this.rays[rayIdentifier];
            var expectedOrigin = _transformationContext.tuples[originIdentifier];
            Assert.Equal(expectedOrigin, ray.Origin);
        }

        [Then(@"the direction of ray (.*) is equal to vector (.*)")]
        public void ThenTheDirectionOfRayRIsEqualToVectorDirection(string rayIdentifier, string directionIdentifier)
        {
            var ray = this.rays[rayIdentifier];
            var expectedDirection = _transformationContext.tuples[directionIdentifier];
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
            _transformationContext.tuples[positionIdentifier] = position;
        }

        [When(@"the normal (.*) is calculated for point (.*)")]
        public void WhenTheNormalNIsCalculatedForPointP(string normalId, string pointId)
        {
            var sphere = spheres["s"];
            var point = _transformationContext.tuples[pointId];

            var result = sphere.NormalAt(point);
            vectors[normalId] = result;
        }

        [Given(@"sphere (.*) has transform (.*)")]
        [When(@"sphere (.*) has transform (.*)")]
        public void WhenSphereHasTransform(string sphereIdentifier, string transformIdentifier)
        {
            Sphere sphere =  this.spheres[sphereIdentifier];
            Matrix transform =_transformationContext.Transforms[transformIdentifier];
            sphere.Transform = transform;
        }

        [Given(@"sphere (.*) has material (.*)")]
        [When(@"sphere (.*) has material (.*)")]
        public void WhenSphereHasMaterial(string sphereIdentifier, string materialId)
        {
            Sphere sphere =  this.spheres[sphereIdentifier];
            Material material = this._colorsContext.Materials[materialId];
            sphere.Material = material;
        }

        [When(@"material (.*) has ambient (.*)")]
        public void WhenMaterialHasAmbient(string materialId, double ambientValue)
        {
            Material material = this._colorsContext.Materials[materialId];
            material.Ambient = ambientValue;
        }

        [Then(@"position (.*) is equal to point \((.*), (.*), (.*)\)")]
        public void ThenPositionPIsEqualToPoint(string positionIdentifier, double x, double y, double z)
        {
            var position = _transformationContext.tuples[positionIdentifier];
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
            Assert.Null(this.Hits);
        }

        [Then(@"the transform of sphere (.*) is equal to matrix (.*)")]
        public void ThenTheTransformOfSphereIsEqualToMatrix(string sphereIdentifier, string matrixId)
        {
            Sphere sphere =  this.spheres[sphereIdentifier];
            Matrix matrix =_matricesContext.Matrices[matrixId];
            Assert.Equal(matrix, sphere.Transform);
        }

        [Then(@"the transform of sphere (.*) is equal to transform (.*)")]
        public void ThenTheTransformOfSphereSIsEqualToTransformT(string sphereIdentifier, string transformIdentifier)
        {
            Sphere sphere =  this.spheres[sphereIdentifier];
            Matrix matrix =_transformationContext.Transforms[transformIdentifier];
            Assert.Equal(matrix, sphere.Transform);
        }

        [Then(@"the vector (.*) is equal to vector \((.*), (.*), (.*)\)")]
        public void ThenTheVectorNIsEqualToVector(string vectorId, double x, double y, double z)
        {
            var expectedVector = TupleLibrary.Tuple.Vector(x, y, z);
            var vector = this.vectors[vectorId];
            Assert.Equal(expectedVector, vector);
        }

        [Then(@"the vector (.*) is normalized")]
        public void ThenTheVectorIsNormalized(string vectorId)
        {
            var vector = this.vectors[vectorId];
            var normalized = vector.Normalize();
            Assert.Equal(normalized, vector);
        }

        [Then(@"the sphere (.*) has material (.*)")]
        public void ThenTheSphereHasMaterial(string sphereIdentifier, string materialId)
        {
            Sphere sphere =  this.spheres[sphereIdentifier];
            Material material = this._colorsContext.Materials[materialId];
            Assert.Equivalent(material, sphere.Material);
        }
    }
}
