namespace TupleLibrary;

public class Lighting
{
    private Material material;
    private PointLight light;
    private Tuple position;
    private Tuple eyeV;
    private Tuple normalV;

    public Lighting(Material material, PointLight light, Tuple position, Tuple eyeV, Tuple normalV)
    {
        this.material = material;
        this.light = light;
        this.position = position;
        this.eyeV = eyeV;
        this.normalV = normalV;
    }
}