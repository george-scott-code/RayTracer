using TupleLibrary;

public class ClockFace
{
    private TupleLibrary.Tuple centre = TupleLibrary.Tuple.Point(0, 0, 0);
    private TupleLibrary.Tuple twelve = TupleLibrary.Tuple.Point(0, 0, 1);

    private List<TupleLibrary.Tuple> points = new List<TupleLibrary.Tuple>(); 

    public ClockFace()
    {
        points.Add(centre);
        points.Add(twelve);

        for(int i = 1; i < 12; i++)
        {
            var rotation = Matrix.RotationY(i * (Math.PI/6));

            var point = rotation * twelve;
            points.Add(point);
        }
    }
}