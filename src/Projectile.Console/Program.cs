using TupleLibrary;
using Sys=System;

internal class Program
{
    private static void Main(string[] args)
    {
        var environment = new Environment(Tuple.Vector(0, -0.1, 0), Tuple.Vector(-0.01, 0, 0));
        var projectile = new Projectile(Tuple.Point(0, 1, 0), Tuple.Vector(1, 1, 0).Normalize());

        while(projectile.Position.Y >= 0.0)
        {
            projectile = Update(environment, projectile);
            Sys.Console.WriteLine($"x position: {projectile.Position.X}");
        }

        //test saving to canvas
        var c = new Canvas(900, 550);
        var start = Tuple.Point(0, 1, 0);

        //The projectile’s velocity was normalized to a unit vector, and then multiplied
        //by 11.25 to increase its magnitude.
        var velo = Tuple.Vector(1, 1.8, 0.0).Normalize() * 11.25;
        var proj = new Projectile(start, velo);

        var grav = Tuple.Vector(0, -0.1, 0);
        var win = Tuple.Vector(-0.1, 0, 0);

        var env = new Environment(grav, win);
    }

    private static Projectile Update(Environment env, Projectile proj)
    {
        return new Projectile(
            proj.Position.Add(proj.Velocity),
            proj.Velocity.Add(env.Wind).Add(env.Gravity)
        );
    }
}