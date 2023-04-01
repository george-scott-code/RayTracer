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
        var width = 100;
        var height = 100;
        var c = new Canvas(width, height);

        var ppm = c.ToPPM();
        File.WriteAllText("saved.ppm", ppm);
    }
}