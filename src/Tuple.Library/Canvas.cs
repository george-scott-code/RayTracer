using System.Text;

namespace TupleLibrary
{
    public class Canvas
    {
        private readonly int _width;
        private readonly int _height;

        public Canvas(int width, int height)
        {
            _width = width;
            _height = height;
            Pixels = new Color[width, height];

            Initialize(new Color(0,0,0));
        }

        public Canvas(int width, int height, Color colour)
        {
            _width = width;
            _height = height;
            Pixels = new Color[width, height];

            Initialize(colour);
        }

        public int Width => _width;
        public int Height => _height;

        public Color[,] Pixels { get; internal set; }

        public void WritePixel(int x, int y, Color color)
        {
            if(x >= 0 && x <= _width &&
                y >= 0 && y <= _height)
            
            Pixels[x,y] = color;       
        }

        public string ToPPM()
        {
            var builder = new StringBuilder();
            builder.AppendLine("P3");
            builder.AppendLine($"{_width} {_height}");
            builder.AppendLine("255");

            for (int y = 0; y < Height; y++)
            {
                int lineLength = 0;
                for (int x = 0; x < Width; x++)
                {
                    string[] colors = Pixels[x, y].ToRGB();
                    foreach (var color in colors)
                    {
                        if(lineLength + 1 + color.Length > 70)
                        {
                            builder.AppendLine();
                            lineLength = 0;
                        }
                        if(lineLength!=0)
                        {
                            builder.Append(" ");
                            lineLength += 1;
                        }
                        lineLength += color.Length;
                        builder.Append(color);
                    }
                }
                builder.AppendLine();
            }

            return builder.ToString();
        }

        private void Initialize(Color color)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Pixels[x, y] = color;
                }
            }
        }
    }
}