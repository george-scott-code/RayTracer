namespace TupleLibrary;

public class Material
{
    public Color Color { get; set; } = new Color(1, 1, 1);
    public double Ambient { get; set; } = 0.1;
    public double Diffuse { get; set; } = 0.9;
    public double Specular { get; set; } = 0.9;
    public double Shininess { get; set; } = 200.0;

    public Material()
    {
        
    }
}
