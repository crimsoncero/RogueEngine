//Emily


namespace RogueEngine.Core
{
    public abstract class TileObject : ICloneable
    {
        public IPosition Position { get; set; }
        public int OwnedBy { get; set; }


        public Movement Movement { get; set; }
        public TileObjectRenderer Renderer { get; set; }
        public Action<TileObject> onLanded { get; set; }
        public Action<TileObject> onPassed { get; set; }


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

        public List<Path> DerivePaths(Tilemap tilemap)
        {
            return Movement.DerivePaths(new Position(Position.X, Position.Y), tilemap, this);
        }

        internal void Selected(Tilemap tilemap)
        {
            DerivePaths(tilemap);
        }
    }
}
