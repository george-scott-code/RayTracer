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
        var canvas_pixels = 100;
        var c = new Canvas(canvas_pixels, canvas_pixels);

        // start the ray at z = -5
        var ray_origin =  Tuple.point(0, 0, -5);
        //  put the wall at z = 10
        var wall_z = 10;
        var wall_size = 7.0;

        // Once you know how many pixels fit along each side of the wall, you can divide
        // the wall size by the number of pixels to get the size of a single pixel (in world
        // space units).
        var pixel_size = wall_size / canvas_pixels;

        // Since the wall is centered around the origin (because the sphere is at the
        // origin), this means that this half variable describes the minimum and maximum
        // x and y coordinates of your wall
        var half = wall_size / 2;

        var ppm = c.ToPPM();
        File.WriteAllText("saved.ppm", ppm);
    }
}