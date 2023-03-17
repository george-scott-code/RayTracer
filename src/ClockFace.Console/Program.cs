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
        var c = new Canvas(30, 30);
        var radius = (30 /8) * 4;
        var blue = new Color(0, 0, 1.5);
        var face = new ClockFace();

        foreach(var point in face.points)
        {
            c.WritePixel((int)(point.X * radius) + 15, (int)(point.Z * radius) + 15, blue);
        }

        var ppm = c.ToPPM();
        File.WriteAllText("saved.ppm", ppm);
    }
}