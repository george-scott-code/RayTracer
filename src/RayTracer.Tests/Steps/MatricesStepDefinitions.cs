using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TupleLibrary;
using Xunit;

namespace RayTracer.Tests.Steps
{
    [Binding]
    public sealed class MatricesStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private Dictionary<string, Matrix> Matrices = new Dictionary<string, Matrix>();

        public MatricesStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a matrix (.*):")]
        public void GivenTheAMatrixM(string matrixIdentifier, Table table)
        {
            //TODO: there must be a better way
            var array = new double[table.RowCount, table.Rows[0].Values.Count];
            for (int row = 0; row < table.Rows.Count; row++)
            {
                var colValues = table.Rows[row].Values.ToArray();
                for (int col = 0; col < colValues.Length; col++)
                {
                    double.TryParse(colValues[col], out double value);
                    array[row, col] = value;
                }
            }
            this.Matrices.Add(matrixIdentifier, new Matrix(array));
        }

        [Then(@"in matrix (.*) the element at \((.*), (.*)\) is (.*)")]
        public void ThenElementIsDouble(string matrixIdentifier, int row, int col, double value)
        {
            var matrix = Matrices.GetValueOrDefault(matrixIdentifier);
            Assert.True(matrix.Element(row,col).Equals(value));
        }
    }
}
