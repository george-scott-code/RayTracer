using Xunit;
using TupleLibrary;

namespace TupleTests
{
    public class TupleTests
    {
        // creation
        [Fact]
        public void Tuple_WithW1_IsPoint()
        {
            Tuple tuple = new Tuple(4.3, -4.2, 1.0);

            Assert.Equal(4.3, tuple.X);
            Assert.Equal(-4.2, tuple.Y);
            Assert.Equal(1.0, tuple.W);
            Assert.True(tuple.IsPoint);
            Assert.False(tuple.IsVector);
        }

        [Fact]
        public void Tuple_WithW0_IsVector()
        {
            Tuple tuple = new Tuple(4.3, -4.2, 0.0);

            Assert.Equal(4.3, tuple.X);
            Assert.Equal(-4.2, tuple.Y);
            Assert.Equal(0.0, tuple.W);
            Assert.False(tuple.IsPoint);
            Assert.True(tuple.IsVector);
        }

        [Fact]
        public void Tuple_WithPointConstructor_IsPoint()
        {
            Tuple tuple = Tuple.Point(4.3, -4.2);
            
            Assert.Equal(4.3, tuple.X);
            Assert.Equal(-4.2, tuple.Y);
            Assert.Equal(1.0, tuple.W);
            Assert.True(tuple.IsPoint);
            Assert.False(tuple.IsVector);
        }

        [Fact]
        public void Tuple_WithPointConstructor_IsVector()
        {
            Tuple tuple = Tuple.Vector(4.3, -4.2);
            
            Assert.Equal(4.3, tuple.X);
            Assert.Equal(-4.2, tuple.Y);
            Assert.Equal(0.0, tuple.W);
            Assert.False(tuple.IsPoint);
            Assert.True(tuple.IsVector);
        }

        // Equality
        [Fact]
        public void Point_EqualsVector_IsNotEqual()
        {
            Tuple vector = Tuple.Vector(4.3, -4.2);
            Tuple point = Tuple.Point(4.3, -4.2);

            Assert.False(point.Equals(vector));
            Assert.False(vector.Equals(point));
        }

        [Fact]
        public void Tuple_EqualsNullTuple_IsNotEqual()
        {
            Tuple t1 = new Tuple(4.3, -4.2, 1.0);
            Tuple t2 = (Tuple) null;

            Assert.False(t1.Equals(t2));
        }

        [Fact]
        public void Tuples_WithSameValues_AreEqual()
        {
            Tuple t1 = new Tuple(4.3, -4.2, 1.0);
            Tuple t2 = new Tuple(4.3, -4.2, 1.0);

            Assert.True(t1.Equals(t2));
            Assert.True(t2.Equals(t1));
        }

        [Fact]
        public void Tuples_WithSameValuesWithinPoint00001_AreEqual()
        {
            double epsilon = 0.00001;
            Tuple t1 = new Tuple(4.3 + epsilon, -4.2, 1.0);
            Tuple t2 = new Tuple(4.3, -4.2, 1.0);

            Assert.True(t1.Equals(t2));
            Assert.True(t2.Equals(t1));
        }

        //Addition

        [Fact]
        public void Point_AddVector_EqualsPoint()
        {
            Tuple t1 = Tuple.Point(1,2);
            Tuple t2 = Tuple.Vector(1,2);

            var result = t1.Add(t2);

            var expected = new Tuple(2,4,1);
            Assert.Equal(expected, result);
            Assert.True(result.IsPoint);
        }
    }
}
