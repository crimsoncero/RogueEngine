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

        public void DeselectTileObject()
        {
            SelectedTileObject = null;
        }

        public bool MoveTileObject(IPosition tileObjPosition, Path path)
        {
            if (!IsThereTileObject(tileObjPosition)) return false;

            TileObject tileObject = this[tileObjPosition].TileObject;
            this[tileObject.Position].TileObject = null;

            // On pass invokes
            if (!tileObject.Pathfinding.EndOnly)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Position pos = new Position(tileObjPosition) + new Position(path[i]);
                   
                    if (!IsValidPosition(pos)) continue;

                    this[pos].OnPassed?.Invoke(tileObject);
                    this[pos].TileObject?.OnPassed?.Invoke(tileObject);
                }
            }
            
            Position finalPos = new Position(tileObjPosition) + new Position(path.Last);

            this[finalPos].PlaceTileObject(tileObject);
            SelectedTileObject = null;
            return true;
        }
        public bool IsTileOwned(IPosition position, int player)
        {
            if (!IsValidPosition(position)) return false;
            if (this[position].OwnedBy == player)
                return true;

            return false;
        }
        public bool IsTileObjectOwned(IPosition position, int player)
        {
            if(!IsValidPosition(position)) return false;
            if (!IsThereTileObject(position)) return false;
           
            if (this[position].TileObject.OwnedBy == player) 
                return true;
            
            return false;
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
