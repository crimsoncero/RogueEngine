//Emily
using System.Collections;

namespace RogueEngine.Core
{

    public class Tilemap : IEnumerable<Tile>
    {
        private Tile[,] tiles;

        public int Width { get; }
        public int Height { get; }

        //Indexer for accessing tiles by coordinates
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


    public class TilemapEnum : IEnumerator<Tile>
    {
        private Tile[,] tiles;

        public Tile Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

}
