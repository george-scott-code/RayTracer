using System;

namespace TupleLibrary.Extensions
{
    public static class DoubleExtensions
    {
        public const double EPSILON = 0.00001;
        
        public static bool DEquals(this double a, double b)
        {
            return Math.Abs(a - b) < EPSILON;
        }

        public static bool DZero(this double a)
        {
            return Math.Abs(a) < EPSILON;
        }
    }
}
