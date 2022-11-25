using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var environment = new Environment(TupleLibrary.Tuple.Vector(0, -0.1, 0), TupleLibrary.Tuple.Vector(-0.01, 0, 0));
        var projectile = new Projectile(TupleLibrary.Tuple.Point(0, 1, 0), TupleLibrary.Tuple.Vector(1, 1, 0).Normalize());

        while(projectile.Position.Y >= 0.0)
        {
            projectile = Tick(environment, projectile);
            System.Console.WriteLine($"x position: {projectile.Position.X}");
        }
    }

    private static Projectile Tick(Environment env, Projectile proj)
    {
        var position = proj.Position.Add(proj.Velocity);
        var velocity = proj.Velocity.Add(env.Wind).Add(env.Gravity);
        return new Projectile(position, velocity);
    }
}