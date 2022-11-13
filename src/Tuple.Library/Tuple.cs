using System;
using TupleLibrary.Extensions;

namespace TupleLibrary
{
    public class Tuple
    {
        public Tuple(double x, double y, double w)
        {
            X = x;
            Y = y;
            W = w;
        }

        public double X { get; init;}
        public double Y { get; init;}
        public double W { get; init;}

        public bool IsPoint => this.W == 1.0;
        public bool IsVector => this.W == 0.0;

        public static Tuple Vector(double x, double y)
        {
            return new Tuple(x, y, 0.0);
        }

        public static Tuple Point(double x, double y)
        {
            return new Tuple(x,y,1.0);
        }

        public override bool Equals(object obj)
        {
            if(obj is null != this is null)
            {
                return false;
            }
            if(obj is null && this is null)
            {
                return true;
            }
            return obj is Tuple tuple &&
                   this.X.DecimalEquals(tuple.X) &&
                   this.Y == tuple.Y &&
                   this.W == tuple.W;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, W);
        }
    }
}
