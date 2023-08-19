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
    }

    public int HSize { get; }
    public int VSize { get; }
    public double FieldOfView { get; }
}
