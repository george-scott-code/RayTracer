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
    }

    public int HSize { get; }
    public int VSize { get; }
    public double FieldOfView { get; }
    public Matrix Transform { get; internal set; }
}
