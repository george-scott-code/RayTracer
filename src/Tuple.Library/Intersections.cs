using System.Linq;

namespace TupleLibrary;

public static class Intersections
{
    public static Intersection Hit(this Intersection[] intersections)
    {
        // TODO: refactor to list
        // TODO: maybe better to maintain the order on construction
        var list = intersections.ToList();
        return list.Where(x => x.T > 0).OrderBy(x => x.T).FirstOrDefault();
    }
}