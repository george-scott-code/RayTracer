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
    public sealed class MatricesStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly MatricesContext _matricesContext;
        private Dictionary<string, Tuple> Tuples = new Dictionary<string, Tuple>();
        private Exception exception;

        public MatricesStepDefinitions(ScenarioContext scenarioContext, MatricesContext matricesContext)
        {
            _scenarioContext = scenarioContext;
            _matricesContext = matricesContext;
        }

        [Given(@"a matrix (.*):")]
        public void GivenTheAMatrixM(string matrixId, Table table)
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
            _matricesContext.Matrices.Add(matrixId, new Matrix(array));
        }

        [Given(@"a tuple\((.*), (.*), (.*), (.*)\) (.*)")]
        public void GivenATuple(double x, double y, double z, double w, string tupleIdentifier)
        {
            var tuple = new Tuple(x, y, z, w);
            Tuples.Add(tupleIdentifier, tuple);
        }
        
        [When(@"matrix (.*) is multiplied by matrix (.*) to create matrix (.*)")]
        public void WhenMatricesAreMultiplied(string matrixAId, string matrixBId, string matrixResultId)
        {
            Matrix matrixA =_matricesContext.Matrices.GetValueOrDefault(matrixAId);
            Matrix matrixB =_matricesContext.Matrices.GetValueOrDefault(matrixBId);
            try 
            {
                Matrix result = matrixA * matrixB;
                _matricesContext.Matrices.Add(matrixResultId, result);
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
            Matrix matrix =_matricesContext.Matrices.GetValueOrDefault(matrixId);
            Tuple tuple = Tuples.GetValueOrDefault(tupleId);
            Tuple result = matrix * tuple;

            this.Tuples.Add("result", result);
        }

        [When(@"matrix (.*) is transposed")]
        public void WhenMatrixIsTransposed(string matrixId)
        {
            Matrix matrix = _matricesContext.Matrices.GetValueOrDefault(matrixId);
            Matrix result = matrix.Transpose();

            _matricesContext.Matrices.Add("result", result);
        }

        [When(@"the submatrix \((.*), (.*)\) of matrix (.*) is calculated")]
        public void WhenTheSubmatrixOfMatrixAIsCalculated(int row, int col, string matrixId)
        {
            Matrix matrix = _matricesContext.Matrices.GetValueOrDefault(matrixId);
            Matrix result = matrix.Submatrix(row, col);

            _matricesContext.Matrices.Add("result", result);
        }

        [When(@"the inverse of matrix (.*) is calculated")]
        public void WhenTheInverseOfMatrixAIsCalculated(string matrixId)
        {
            Matrix matrix = _matricesContext.Matrices.GetValueOrDefault(matrixId);
            Matrix result = matrix.Inverse();

            _matricesContext.Matrices.Add("result", result);
        }

        [Then(@"the determinant of matrix (.*) is (.*)")]
        public void ThenTheDeterminantOfMatrixAIs(string matrixId, double value)
        {
            var matrix = _matricesContext.Matrices.GetValueOrDefault(matrixId);
            Assert.True(matrix.Determinant().Equals(value));
        }

        [Then(@"the minor \((.*), (.*)\) of matrix (.*) is (.*)")]
        public void ThenTheMinorOfMatrixIs(int row, int col, string matrixId, double value)
        {
            var matrix = _matricesContext.Matrices.GetValueOrDefault(matrixId);
            Assert.True(matrix.Minor(row, col).Equals(value));
        }

        [Then(@"the cofactor \((.*), (.*)\) of matrix (.*) is (.*)")]
        public void ThenTheCofactorOfMatrixIs(int row, int col, string matrixId, double value)
        {
            var matrix = _matricesContext.Matrices.GetValueOrDefault(matrixId);
            Assert.True(matrix.Cofactor(row, col).Equals(value));
        }

        [Then(@"in matrix (.*) the element at \((.*), (.*)\) is (.*)")]
        public void ThenElementIsDouble(string matrixId, int row, int col, double expected)
        {
            var matrix = _matricesContext.Matrices.GetValueOrDefault(matrixId);
            var element = matrix.Element(row,col);
            Assert.True(expected.DEquals(element));
        }

        [Then(@"matrix (.*) (is|is not) equal to matrix (.*)")]
        public void ThenMatrixEquality(string matrixAId, string condition, string matrixBId)
        {
            Matrix matrixA = _matricesContext.Matrices.GetValueOrDefault(matrixAId);
            Matrix matrixB = _matricesContext.Matrices.GetValueOrDefault(matrixBId);
            bool equality = condition == "is";

            Assert.Equal(equality, matrixA.Equals(matrixB));
            Assert.Equal(equality, matrixB.Equals(matrixA));
        }

        [Then(@"the matrix (.*) (is|is not) invertible")]
        public void ThenTheMatrixAIsNotInvertible(string matrixId, string condition)
        {
            Matrix matrix =_matricesContext.Matrices.GetValueOrDefault(matrixId);
            bool invertible = condition == "is";

            Assert.Equal(invertible, matrix.IsInvertable());
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
