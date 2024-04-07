//Emily

namespace RogueEngine.Core
{

    public  class Tile
    {
        public TileObject TileObject { get; set; }
        public IPosition Position { get; }
        public int OwnedBy { get; set; }
        public TileRenderer Renderer { get; set; }
        public Action<TileObject> onTileLanded { get; set; }
        public Action<TileObject> onTilePassed { get; set; }

        //tile with full parameters
        public Tile(TileObject tileObject, IPosition position, int ownedBy)
        {
            TileObject = tileObject;
            Position = position;
            OwnedBy = ownedBy;
        }

        //tile not owned by any player
        public Tile(TileObject tileObject, IPosition position)
            : this(tileObject, position, -1)
        {
        }

        //blank tile (not owned and without any object)
        public Tile(IPosition position)
            : this(null, position, -1)
        {
        }

        public bool IsEmpty()
        {
            return TileObject == null;
        }

        public void PlaceTileObject(TileObject tileObject)
        {
            if (IsEmpty())
            {
                TileObject = tileObject;
                onTileLanded?.Invoke(tileObject);
            }
            else
            {
                Console.WriteLine("Cannot place a tile object on a non-empty tile.");
            }
        }

        public void PassTile(TileObject tileObject)
        {
            if (onTilePassed != null)
            {
                onTilePassed.Invoke(tileObject);
            }
            else
            {
                Console.WriteLine($"Tile at position {Position} was passed over.");
            }
        }

        public void RemoveTileObject()
        {
            TileObject = null;
        }
    }
}
