using TupleLibrary;
using Sys=System;

internal partial class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        SaveToCanvas();
    }

    //TODO: separate computation and presentation
    private static void SaveToCanvas()
    {
        var canvas_pixels = 100;
        var c = new Canvas(canvas_pixels, canvas_pixels);

        // start the ray at z = -5
        TupleLibrary.Tuple ray_origin =  TupleLibrary.Tuple.Point(0, 0, -5);
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

        var color = new Color(1, 0, 0); // red
        var shape = new Sphere();

        // shrink it along the y axis
        // shape.Transformation = TupleLibrary.Matrix.Scaling(1.0, 0.5, 1.0);
        
        // for each row of pixels in the canvas
        for(int y = 0; y < canvas_pixels; y++)
        {
            //compute the world y coordinate (top = +half, bottom = -half)
            var world_y = half - pixel_size * y;

            // for each pixel in the row
            for(int x = 0; x < canvas_pixels; x++)
            {
                //compute the world x coordinate (left = -half, right = half)
                var world_x = -half + pixel_size * x;

                //describe the point on the wall that the ray will target
                TupleLibrary.Tuple position = TupleLibrary.Tuple.Point(world_x, world_y, wall_z);
                var r = new Ray(ray_origin, (position.Subtract(ray_origin)).Normalize());
                var xs = shape.Intersection(r);
                var hit = xs.Hit();
                if(hit != null)
                {
                    c.WritePixel(x, y, color);
                }
            }
        }

        var ppm = c.ToPPM();
        File.WriteAllText("saved.ppm", ppm);
    }
}