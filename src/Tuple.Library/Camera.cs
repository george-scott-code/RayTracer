using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace TupleLibrary;

public class Camera
{
    public Camera()
    {
        
    }

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
        var halfView =Math.Tan(FieldOfView / 2);
        var aspect = HSize / VSize;
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
}