using System;

namespace TupleLibrary;

public class Material : IEquatable<Material>
{
    public Color Color { get; set; }
    public double Ambient { get; set; }
    public double Diffuse { get; set; }
    public double Specular { get; set; }
    public double Shininess { get; set; }

    public Material()
    {
        this.Color =  new Color(1, 1, 1);
        this.Ambient = 0.1;
        this.Diffuse = 0.9;
        this.Specular = 0.9;
        this.Shininess = 200.00;

    }

    public Material(Color color, double ambient, double diffuse, double specular, double shininess)
    {
        this.Color = color;
        this.Ambient = ambient;
        this.Diffuse = diffuse;
        this.Specular = specular;
        this.Shininess = shininess;
    }

    public bool Equals(Material other)
    {
        if (other is null)
        {
            return false;
        }

        if (Object.ReferenceEquals(this, other))
        {
            return true;
        }
        if (this.GetType() != other.GetType())
        {
            return false;
        }
        return (this.Color.Equals(other.Color));
    }
}
