//Emily

namespace RogueEngine.Core
{
    public abstract class TileObject : ICloneable
    {
        public IPosition Position { get; set; }
        public int OwnedBy { get; set; }


        public Movement Movement { get; set; }
        public TileObjectRenderer Renderer { get; set; }

        public TileObject(int ownedBy)
        {
            OwnedBy = ownedBy;
        }

        //constructor not owned by any player
        public TileObject()
        : this(-1)
        {
        }

        public virtual object Clone()
        {
            TileObject clone = (TileObject)Activator.CreateInstance(this.GetType());

            clone.Position = Position;
            clone.OwnedBy = OwnedBy;
            //clone.Renderer = Renderer.Clone();// add in renderer

            return clone;
        }

        //moving the tile object to another tile
        public virtual void MoveToTile(Tile currentTile, Tile targetTile)
        {
            Console.WriteLine($"Moving tile object from {currentTile.Position} to {targetTile.Position}");
        }

        public virtual void PassTile(Tile tile)
        {
            if (tile != null && tile.onTilePassed != null)
            {
                tile.PassTile(this);
            }
            else
            {
                Console.WriteLine($"Passing through tile {tile.Position}");
            }
        }

        public virtual void LandOnTile(Tile tile)
        {
            if (tile != null && tile.onTileLanded != null) 
            { 
                tile.PlaceTileObject(this);
            }
            else
            {
                Console.WriteLine($"{this} landed on tile {tile.Position}");
            }
        }
    }
}
