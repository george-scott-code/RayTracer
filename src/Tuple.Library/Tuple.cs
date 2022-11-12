using System;

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
    }
}
