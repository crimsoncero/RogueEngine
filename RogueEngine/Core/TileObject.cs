//Emily
using RogueEngine.Position;

namespace RogueEngine.Core
{

    public abstract class TileObject : ICloneable
    {
        public IPosition Position { get; }
        public int OwnedBy { get; set; }

        public TileObject(int ownedBy)
        {
            OwnedBy = ownedBy;
        }

        //constructor not owned by any player
        public TileObject()
        : this(-1)
        {
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        //moving the tile object to another tile
        public virtual void MoveToTile(Tile currentTile, Tile targetTile)
        {
            
            Console.WriteLine($"Moving tile object from {currentTile.Position} to {targetTile.Position}");
        }

        //interacting with a tile when passing through it
        public virtual void PassTile(Tile tile)
        {
            // Implement passing logic here
            Console.WriteLine($"Passing through tile {tile.Position}");
        }

        //interacting with a tile when landing on it
        public virtual void LandOnTile(Tile tile)
        {
            // Implement landing logic here
            Console.WriteLine($"Landing on tile {tile.Position}");
        }
    }
}
