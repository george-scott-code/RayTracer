using System.Collections.Generic;
using TupleLibrary;

namespace RayTracer.Tests.Steps;

public class ColorsContext
{
    public Dictionary<string, Color> Colors = new Dictionary<string, Color>();
    public Dictionary<string, Material> Materials = new Dictionary<string, Material>();
    public Dictionary<string, PointLight> Lights = new Dictionary<string, PointLight>();
}
