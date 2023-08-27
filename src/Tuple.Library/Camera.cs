using System;

namespace TupleLibrary;

public class Camera
{
    public Camera(int hSize, int vSize, double fieldOfView)
    {
        HSize = hSize;
        VSize = vSize;
        FieldOfView = fieldOfView;
        Transform = Matrix.Identity();
        GeneratePixelSize();
    }

    public int HSize { get; }
    public int VSize { get; }
    public double FieldOfView { get; }
    public Matrix Transform { get; internal set; }
    public double PixelSize { get; internal set; }
    public double HalfWidth { get; private set; }
    public double HalfHeight { get; private set; }

    internal void GeneratePixelSize()
    {
        var halfView = Math.Tan(FieldOfView / 2);
        var aspect = (double) HSize / VSize;
        if (aspect >= 1)
        {
            HalfWidth = halfView;
            HalfHeight = halfView / aspect;
        }
        else
        {
            HalfWidth = halfView * aspect;
            HalfHeight = halfView;
        }

        PixelSize = (HalfWidth * 2) / HSize;
    }

    internal Ray RayForPixel(int px, int py)
    {
        // the offset from the edge of the canvas to the pixel center
        var xOffset = (px + 0.5) * PixelSize;
        var yOffset = (py + 0.5) * PixelSize;

        // the untransformed coordinates of the pixel in world space
        // remember that the camera looks toward -z, so +x is to the left
        var worldX = HalfWidth - xOffset;
        var worldY = HalfHeight - yOffset;

        // using the camera matrix, transform the canvas point and the origin,
        // and then compute the ray's direction vector.
        // (remember that the canvas is at z=-1)
        var inverseTransform = Transform.Inverse();
        var pixel = inverseTransform * Tuple.Point(worldX, worldY, -1);
        var origin = inverseTransform * Tuple.Point(0, 0, 0);
        var direction = pixel.Add(-origin).Normalize();
           
        return new Ray(origin, direction);
    }

    internal Canvas Render(World w)
    {
        var image = new Canvas(HSize, VSize);
        for (int y = 0; y < VSize; y++)
        {
            for (int x = 0; x < HSize; x++)
            {
                var ray = RayForPixel(x, y);
                var color = w.ColorAt(ray);
                image.WritePixel(x, y, color);
            }
        }
        return image;
    }   
}