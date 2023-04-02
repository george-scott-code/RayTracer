using System.Collections.Generic;
using TupleLibrary;

namespace RayTracer.Tests.Steps
{
    public class TransformationContext
    {
        public Dictionary<string, Matrix> Transforms = new();
        public Dictionary<string, Tuple> tuples = new Dictionary<string, Tuple>();
    }
}
