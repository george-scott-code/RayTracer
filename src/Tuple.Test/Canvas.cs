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

        public int Height => _height;
        public int Width => _width;

        public Color[,] Pixels { get; internal set; }

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