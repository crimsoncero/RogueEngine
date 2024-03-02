//Emily
using System.Collections;

namespace RogueEngine.Core
{

    public class Tilemap : IEnumerable<Tile>
    {
        private readonly Tile[,] tiles;

        public int Width { get; }
        public int Height { get; }

        //Indexer for accessing tiles by coordinates
        public Tile this[int x, int y]
        {
            get { return tiles[x, y]; }
            set { tiles[x, y] = value; }
        }

        //implementation of IEnumerable and IEnumerator
        public IEnumerator<Tile> GetEnumerator()
        {
            foreach (Tile tile in tiles)
            {
                yield return tile;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //method to check if a position is valid
        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }
}
