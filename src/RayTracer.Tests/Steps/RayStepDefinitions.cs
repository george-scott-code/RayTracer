using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TupleLibrary;
using TupleLibrary.Extensions;
using Xunit;
using Tuple = TupleLibrary.Tuple;

namespace RayTracer.Tests.Steps
{
    [Binding]
    public sealed class RayStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private Dictionary<string, Tuple> tuples = new Dictionary<string, Tuple>();
        private Dictionary<string, Tuple> vectors = new();
        private Dictionary<string, Ray> rays = new();


        private Exception exception;

        public RayStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        // [Given(@"a matrix (.*):")]
        // public void GivenTheAMatrixM(string matrixIdentifier, Table table)
        // {
        //     //TODO: there must be a better way
        //     var array = new double[table.RowCount, table.Rows[0].Values.Count];
        //     for (int row = 0; row < table.Rows.Count; row++)
        //     {
        //         var colValues = table.Rows[row].Values.ToArray();
        //         for (int col = 0; col < colValues.Length; col++)
        //         {
        //             double.TryParse(colValues[col], out double value);
        //             array[row, col] = value;
        //         }
        //     }
        //     this.Matrices.Add(matrixIdentifier, new Matrix(array));
        // }

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

    }
}
