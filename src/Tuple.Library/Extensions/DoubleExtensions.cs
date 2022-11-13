using System;

namespace TupleLibrary.Extensions
{
    public static class DoubleExtensions
    {
        private const double EPSILON = 0.00001;
        public static bool DecimalEquals(this double a, double b)
        {
            if(Math.Abs(a) - Math.Abs(b) < EPSILON)
            {
                return true;
            }
            return false;
        }
    }
}
