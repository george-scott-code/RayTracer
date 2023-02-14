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
    public sealed class MatricesStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private Dictionary<string, Matrix> Matrices = new Dictionary<string, Matrix>();
        private Dictionary<string, Tuple> Tuples = new Dictionary<string, Tuple>();
        private Exception exception;

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

        [Given(@"a tuple\((.*), (.*), (.*), (.*)\) (.*)")]
        public void GivenATuple(double x, double y, double z, double w, string tupleIdentifier)
        {
            var tuple = new Tuple(x, y, z, w);
            Tuples.Add(tupleIdentifier, tuple);
        }

        [When(@"matrix (.*) is multiplied by matrix (.*)")]
        public void WhenMatricesAreMultiplied(string matrixAId, string matrixBId)
        {
            Matrix matrixA = Matrices.GetValueOrDefault(matrixAId);
            Matrix matrixB = Matrices.GetValueOrDefault(matrixBId);
            try 
            {
                Matrix result = matrixA * matrixB;
                this.Matrices.Add("result", result);
            }
            catch (Exception e)
            {
                this.exception = e;
                return;
            }
        }

        [When(@"matrix (.*) is multiplied by tuple (.*)")]
        public void WhenMatrixAndTupleAreMultiplied(string matrixId, string tupleId)
        {
            Matrix matrix = Matrices.GetValueOrDefault(matrixId);
            Tuple tuple = Tuples.GetValueOrDefault(tupleId);
            Tuple result = matrix * tuple;

            this.Tuples.Add("result", result);
        }

        [When(@"matrix (.*) is transposed")]
        public void WhenMatrixIsTransposed(string matrixId)
        {
            Matrix matrix = Matrices.GetValueOrDefault(matrixId);
            Matrix result = matrix.Transpose();

            this.Matrices.Add("result", result);
        }

        [When(@"the submatrix \((.*), (.*)\) of matrix (.*) is calculated")]
        public void WhenTheSubmatrixOfMatrixAIsCalculated(int row, int col, string matrixIdentifier)
        {
            Matrix matrix = Matrices.GetValueOrDefault(matrixIdentifier);
            Matrix result = matrix.Submatrix(row, col);

            this.Matrices.Add("result", result);
        }

        [Then(@"the determinant of matrix (.*) is (.*)")]
        public void ThenTheDeterminantOfMatrixAIs(string matrixIdentifier, double value)
        {
            var matrix = Matrices.GetValueOrDefault(matrixIdentifier);
            Assert.True(matrix.Determinant().Equals(value));
        }

        [Then(@"the minor \((.*), (.*)\) of matrix (.*) is (.*)")]
        public void ThenTheMinorOfMatrixAIs(int row, int col, string matrixIdentifier, double value)
        {
            var matrix = Matrices.GetValueOrDefault(matrixIdentifier);
            Assert.True(matrix.Minor(row, col).Equals(value));
        }

        [Then(@"in matrix (.*) the element at \((.*), (.*)\) is (.*)")]
        public void ThenElementIsDouble(string matrixIdentifier, int row, int col, double value)
        {
            var matrix = Matrices.GetValueOrDefault(matrixIdentifier);
            Assert.True(matrix.Element(row,col).Equals(value));
        }

        [Then(@"matrix (.*) (is|is not) equal to matrix (.*)")]
        public void ThenMatrixEquality(string matrixAId, string condition, string matrixBId)
        {
            Matrix matrixA = Matrices.GetValueOrDefault(matrixAId);
            Matrix matrixB = Matrices.GetValueOrDefault(matrixBId);
            bool equality = condition == "is";

            Assert.Equal(equality, matrixA.Equals(matrixB));
            Assert.Equal(equality, matrixB.Equals(matrixA));
        }

        [Then(@"tuple result is equal to tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenTheResultIsTuple(double x, double y, double z, double w)
        {
            Tuple expected = new Tuple(x ,y, z, w);
            Tuple result = Tuples.GetValueOrDefault("result");
            Assert.Equal(expected, result);
        }

        [Then(@"an (.*) was thrown")]
        public void ThenAnExceptionWasThrown(string exceptionType)
        {
            switch (exceptionType)
            {
                case "ArgumentException":
                    Assert.True(this.exception != null && this.exception is ArgumentException);
                    break;
                default:
                    break;
            }   
        }
    }
}
