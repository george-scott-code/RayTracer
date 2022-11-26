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
    }

    private static Projectile Update(Environment env, Projectile proj)
    {
        return new Projectile(
            proj.Position.Add(proj.Velocity),
            proj.Velocity.Add(env.Wind).Add(env.Gravity)
        );
    }
}