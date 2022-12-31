using System.IO;
using TupleLibrary;
using Sys=System;

internal class Program
{
    private static void Main(string[] args)
    {
        SaveToCanvas();
    }

    private static void PrintToConsole()
    {
        var environment = new Environment(Tuple.Vector(0, -0.1, 0), Tuple.Vector(-0.01, 0, 0));
        var projectile = new Projectile(Tuple.Point(0, 1, 0), Tuple.Vector(1, 1, 0).Normalize());

        while(projectile.Position.Y >= 0.0)
        {
            projectile = Update(environment, projectile);
            Sys.Console.WriteLine($"x position: {projectile.Position.X}");
        }
    }

    private static void SaveToCanvas()
    {
        //test saving to canvas
        var c = new Canvas(900, 550);
        var start = Tuple.Point(0, 1, 0);

        //The projectile’s velocity was normalized to a unit vector, and then multiplied
        //by 11.25 to increase its magnitude.
        var velo = Tuple.Vector(1, 1.8, 0.0).Normalize() * 11.25;
        var velo2 = Tuple.Vector(1, 0.9, 0.0).Normalize() * 9.5;

        var proj = new Projectile(start, velo);
        var proj2 = new Projectile(start, velo2);

        var grav = Tuple.Vector(0, -0.1, 0);
        var win = Tuple.Vector(-0.01, 0, 0);

        var env = new Environment(grav, win);
        var red = new Color(1.5, 0, 0);
        var blue = new Color(0, 0, 1.5);


        while(proj.Position.Y >= 0.0)
        {
            proj = Update(env, proj);
            if(proj.Position.X >= 0 && 
                proj.Position.X <= 900 &&
                proj.Position.Y >= 0 &&
                proj.Position.Y <= 550)
            c.WritePixel((int)proj.Position.X, (550 - (int)proj.Position.Y), red);
        }

        while(proj2.Position.Y >= 0.0)
        {
            proj2 = Update(env, proj2);
            if(proj2.Position.X >= 0 && 
                proj2.Position.X <= 900 &&
                proj2.Position.Y >= 0 &&
                proj2.Position.Y <= 550)
            c.WritePixel((int)proj2.Position.X, (550 - (int)proj2.Position.Y), blue);
        }
        var ppm = c.ToPPM();
        File.WriteAllText("saved.ppm", ppm);
    }

    private static Projectile Update(Environment env, Projectile proj)
    {
        return new Projectile(
            proj.Position.Add(proj.Velocity),
            proj.Velocity.Add(env.Wind).Add(env.Gravity)
        );
    }
}