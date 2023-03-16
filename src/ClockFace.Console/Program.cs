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
        var start = TupleLibrary.Tuple.Point(15, 15, 0);

        //write a pixel to the centre of the canvas
        var red = new Color(1.5, 0, 0);
        var blue = new Color(0, 0, 1.5);

        c.WritePixel((int)start.X, (int)start.Y, red);

        var transform = Matrix.Translation(0, 5, 0);

        var twelve = transform * start;
        c.WritePixel((int)twelve.X, (int)twelve.Y, blue);

        var ppm = c.ToPPM();
        File.WriteAllText("saved.ppm", ppm);
    }
}