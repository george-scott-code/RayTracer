using System;
using System.Text;
using TupleLibrary;

namespace TupleTests
{
    internal class Canvas
    {
        private int _width;
        private int _height;

        public Canvas(int width, int height)
        {
            this._width = width;
            this._height = height;
            Pixels = new Color[width, height];

            Initialize(new Color(0,0,0));
        }

        public int Width => _width;
        public int Height => _height;

        public Color[,] Pixels { get; internal set; }

        public void WritePixel(int x, int y, Color color)
        {
            Pixels[x,y] = color;       
        }

        public string ToPPM()
        {
            var builder = new StringBuilder();
            builder.AppendLine("P3");
            builder.AppendLine($"{_width} {_height}");
            builder.AppendLine("255");

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