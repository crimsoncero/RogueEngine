//Emily
using System.Collections;

namespace RogueEngine.Core
{

    public class Tilemap : IEnumerable<Tile>
    {
        private Tile[,] tiles;

        public int Width { get; }
        public int Height { get; }

        public Tile this[int x, int y]
        {
            get { return tiles[x, y]; }
            set { tiles[x, y] = value; }
        }

        public Tile this[IPosition position]
        {
            get { return this[position.X, position.Y]; }
            set { this[position.X, position.Y] = value; }
        }

        public Tilemap(int width, int height)
        {
            Width = width;
            Height = height;
            tiles = new Tile[Width, Height];
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    yield return tiles[x, y];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
