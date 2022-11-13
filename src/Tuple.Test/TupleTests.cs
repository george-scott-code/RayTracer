using Xunit;
using TupleLibrary;

namespace TupleTests
{
    public class TupleTests
    {
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
    }
}
