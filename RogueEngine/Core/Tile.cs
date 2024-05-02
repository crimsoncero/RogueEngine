//Emily

namespace RogueEngine.Core
{

    public abstract class Tile
    {
        public TileObject TileObject { get; set; }
        public IPosition Position { get; }
        public int OwnedBy { get; set; }
        public TileRenderer Renderer { get; set; }
        public Action<TileObject> OnLanded { get; set; }
        public Action<TileObject> OnPassed { get; set; }

        public bool IsEmpty { get { return TileObject == null; } }

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


        public virtual void PlaceTileObject(TileObject tileObject)
        {

            TileObject?.OnLanded?.Invoke(tileObject);

            TileObject = tileObject;
            tileObject.Position = Position;
            OnLanded?.Invoke(tileObject);
        }


        public void RemoveTileObject()
        {
            TileObject = null;
        }
    }
}
