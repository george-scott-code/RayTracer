using TupleLibrary;

internal partial class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        SaveToCanvas();
    }

    private static void SaveToCanvas()
    {
        var width = 30;
        var height = 30;
        var c = new Canvas(width, height);
        var radius = (30 /8) * 4;
        var start = TupleLibrary.Tuple.Point(0, 0, -1);

        var face = new ClockFace();

        foreach(var point in face.points)
        {
            c.WritePixel((int)(point.X * radius) + (width/2), (int)(point.Z * radius) + (width/2), new Color(0, 0, 1.5));
        }

        c.WritePixel((int)(start.X * radius) + (width/2), (int)(start.Z * radius) + (width/2), new Color(1.5, 0, 0));

        var ppm = c.ToPPM();
        File.WriteAllText("saved.ppm", ppm);
    }
}