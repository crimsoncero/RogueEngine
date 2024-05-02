//Emily


namespace RogueEngine.Core
{
    public abstract class TileObject : ICloneable
    {
        public IPosition Position { get; set; }
        public int OwnedBy { get; set; }


        public Pathfinding Pathfinding { get; set; }
        public TileObjectRenderer Renderer { get; set; }
        public Action<TileObject> OnLanded { get; set; }
        public Action<TileObject> OnPassed { get; set; }


        public TileObject(IPosition position, int ownedBy)
        {
            Position = position;
            OwnedBy = ownedBy;
            Pathfinding = new Pathfinding();
            SetMovementConditions();
        }

        //constructor not owned by any player
        public TileObject(IPosition position)
        : this(position,-1)
        {
        }

        /// <summary>
        /// Set the movement Conditions for the tile object.
        /// </summary>
        protected abstract void SetMovementConditions();


        public virtual object Clone()
        {
            TileObject clone = (TileObject)Activator.CreateInstance(this.GetType());

            clone.Position = Position;
            clone.OwnedBy = OwnedBy;
            //clone.Renderer = Renderer.Clone();// add in renderer

            return clone;
        }

        /// <summary>
        /// Derives the possible paths the TileObject can go use.
        /// Override to create a new pipeline for deriving paths different from the Pathfinding Module Pipeline.
        /// </summary>
        /// <param name="tilemap"></param>
        /// <returns></returns>
        public virtual List<Path> DerivePaths(Tilemap tilemap)
        {
            return Pathfinding.DerivePaths(new Position(Position.X, Position.Y), tilemap, this);
        }

        internal void Selected(Tilemap tilemap)
        {
            DerivePaths(tilemap);
        }
    }
}
