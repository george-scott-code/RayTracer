using TupleLibrary;
using Sys=System;

internal partial class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // SaveToCanvas();
        RenderScene();
    }
    
    private static void RenderScene()
    {
        var w = new World();
        w.Light = new PointLight(TupleLibrary.Tuple.Point(-10, 10, -10), new Color(1, 1, 1));
        
        // create walls
        var wallMaterial = new Material()
        {
            Color = new Color(1, 0.9, 0.9),
            Specular = 0
        };

        var floor = new Sphere(wallMaterial, Matrix.Scaling(10, 0.01, 10));

        var lWallTransform = Matrix.Translation(0, 0, 5) * 
            Matrix.RotationY(-Math.PI/4) *
            Matrix.RotationX(Math.PI/2) *
            Matrix.Scaling(10, 0.01, 10);
        var rWallTransform = Matrix.Translation(0, 0, 5) * 
            Matrix.RotationY(Math.PI/4) *
            Matrix.RotationX(Math.PI/2) *
            Matrix.Scaling(10, 0.01, 10);

        var lWall = new Sphere(wallMaterial, lWallTransform);
        var rWall = new Sphere(wallMaterial, rWallTransform);

        // add objects
        var material = new Material()
        {
            Color = new Color(0.1, 1, 0.5),
            Diffuse = 0.7,
            Specular = 0.3
        };

        var middle = new Sphere(material, Matrix.Translation(-0.5, 1, 0.5));

        w.Objects = new List<Sphere>()
        {
            floor,
            lWall,
            rWall,
            middle
        };

        var from = TupleLibrary.Tuple.Point(0, 1.5, -5);
        var to = TupleLibrary.Tuple.Point(0, 1, 0);
        var up = TupleLibrary.Tuple.Vector(0, 1, 0);
        var c = new Camera(100, 50, Math.PI / 3)
        {
            Transform = Matrix.ViewTransform(from, to, up)
        };

        var image = c.Render(w);
        var ppm = image.ToPPM();
        File.WriteAllText("scene.ppm", ppm);
    }

    //TODO: separate computation and presentation
    //TODO: render the same image using world / camera
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
        var material = new Material();
        material.Color = new Color(1, 0.2, 1);

        shape.Material = material;

        // white light
        // behind, above and to the left of the eye
        var light_position = TupleLibrary.Tuple.Point(-10, 10, -10);
        var light_color = new Color(1, 1, 1);
        var light = new PointLight(light_position, light_color);   

        // shrink it along the y axis
        // shape.Transform = TupleLibrary.Matrix.Scaling(1.0, 0.5, 1.0);
        
        // for each row of pixels in the canvas
        for (int y = 0; y < canvas_pixels; y++)
        {
            //compute the world y coordinate (top = +half, bottom = -half)
            var world_y = half - pixel_size * y;

            // for each pixel in the row
            for (int x = 0; x < canvas_pixels; x++)
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
                    var point = r.Position(hit.T);
                    var normal = hit.Obj.NormalAt(point);
                    var eye = -r.Direction;
                    var lighting = Lighting.GetLighting(hit.Obj.Material, light, point, eye, normal);
                    c.WritePixel(x, y, lighting);
                }
            }
        }

        var ppm = c.ToPPM();
        File.WriteAllText("saved.ppm", ppm);
    }
}