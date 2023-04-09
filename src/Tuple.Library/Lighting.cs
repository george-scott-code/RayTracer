using System;

namespace TupleLibrary;

public static class Lighting
{
    public static Color GetLighting(Material material, PointLight light, Tuple point, Tuple eyeV, Tuple normalV)
    {
        Color diffuse = new Color(0, 0, 0);
        Color specular = new Color(0, 0, 0);
        // combine the surface color with the light's color/intensity
        var effective_color = material.Color * light.Intensity;
        // find the direction to the light source
        var lightv = (light.Position.Subtract(point)).Normalize();
        // compute the ambient contribution
        var ambient = effective_color * material.Ambient;
        // light_dot_normal represents the cosine of the angle between the
        // light vector and the normal vector. A negative number means the
        // light is on the other side of the surface.
        var light_dot_normal = lightv.Dot(normalV);
        if (light_dot_normal < 0)
        {
            diffuse = new Color(0, 0, 0); //black
            specular = new Color(0, 0, 0);
        }
        else
        {
            // compute the diffuse contribution
            diffuse = effective_color * material.Diffuse * light_dot_normal;
            // reflect_dot_eye represents the cosine of the angle between the
            // reflection vector and the eye vector. A negative number means the
            // light reflects away from the eye.
            var reflectv = (-lightv).Reflect(normalV);
            var reflect_dot_eye = reflectv.Dot(eyeV);

            if (reflect_dot_eye <= 0)
            {
                specular = new Color(0, 0, 0);
            }
            else
            {
                // compute the specular contribution
                var factor = Math.Pow(reflect_dot_eye, material.Shininess);
                specular = light.Intensity * material.Specular * factor;
            }
        }
        // Add the three contributions together to get the final shading
        return ambient + diffuse + specular;
    }
}