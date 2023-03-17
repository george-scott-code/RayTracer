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
        //test saving to canvas
        var c = new Canvas(30, 30);
        var radius = (30 /8) * 3;
        var start = TupleLibrary.Tuple.Point(0, 0, 0);

        //write a pixel to the centre of the canvas
        var red = new Color(1.5, 0, 0);
        var blue = new Color(0, 0, 1.5);

        c.WritePixel((int)start.X + 15, (int)start.Z + 15, red);

        var transform = Matrix.Translation(0, 0, 1);

        var twelve = TupleLibrary.Tuple.Point(0, 0, 1);
        c.WritePixel((int)twelve.X * radius + 15, (int)twelve.Z * radius + 15, blue);

        //rotation
        var rotation = Matrix.RotationY(3 * (Math.PI/6));

        var one = rotation * twelve;
        c.WritePixel((int)one.X * radius + 15, (int)one.Z * radius + 15, blue);

        var ppm = c.ToPPM();
        File.WriteAllText("saved.ppm", ppm);
    }
}