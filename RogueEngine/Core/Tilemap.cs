//Emily
using System.Collections;

namespace RogueEngine.Core
{

    public abstract class Tilemap : IEnumerable<Tile>
    {
        private Tile[,] _map;

        public int Width { get; }
        public int Height { get; }

        public TileObject SelectedTileObject { get; private set; }

        public Tile this[int x, int y]
        {
            get { return _map[x, y]; }
            set { _map[x, y] = value; }
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
            _map = new Tile[Width, Height];
        }

        public abstract void Init();


        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
        public bool IsValidPosition(IPosition position)
        {
            return IsValidPosition(position.X, position.Y);
        }

        public bool IsThereTileObject(int x, int y)
        {
            return IsThereTileObject(new Position(x, y));
        }
        public bool IsThereTileObject(IPosition tileObjPosition)
        {
            if (tileObjPosition == null) return false;
            if (!IsValidPosition(tileObjPosition)) return false;

            if (this[tileObjPosition].TileObject == null) return false;

            return true;
        }

        public bool SelectTileObject(IPosition tileObjPosition)
        {
            if(!IsThereTileObject(tileObjPosition))
                return false;

            SelectedTileObject = this[tileObjPosition].TileObject;
            SelectedTileObject.Selected(this);
            return true;

        }

        public bool MoveTileObject(IPosition tileObjPosition, Path path)
        {
            if (!IsThereTileObject(tileObjPosition)) return false;

            TileObject tileObject = this[tileObjPosition].TileObject;
            
            // On pass invokes
            if (!tileObject.Movement.EndOnly)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Position pos = new Position(tileObjPosition.X, tileObjPosition.Y) + new Position(path.Last.X, path.Last.Y);
                   
                    if (!IsValidPosition(pos)) continue;

                    this[pos].onPassed?.Invoke(tileObject);
                    this[pos].TileObject?.onPassed?.Invoke(tileObject);
                }
            }
            
            Position finalPos = new Position(tileObjPosition.X, tileObjPosition.Y) + new Position(path.Last.X, path.Last.Y);

            if (!IsValidPosition(finalPos)) return false;

            this[finalPos].PlaceTileObject(tileObject);
            return true;
        }


        public IEnumerator<Tile> GetEnumerator()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    yield return _map[x, y];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}
