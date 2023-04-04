namespace TupleLibrary;

public class PointLight
{
    public TupleLibrary.Tuple Position { get; }
    public Color Intensity { get; }

    public PointLight(TupleLibrary.Tuple position, Color intensity)
    {
        this.Position = position;
        this.Intensity = intensity;
    }
}
