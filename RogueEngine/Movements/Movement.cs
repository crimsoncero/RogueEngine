

namespace RogueEngine.Movements
{
    public class Movement
    {
        private List<Path> _paths;
        public List<Path> DerivedPaths { get; private set; }
        public List<MoveCondition> MoveConditions { get; set; }
        
        public bool EndOnly { get; set; } = false;
        public Movement(ICollection<Path> paths)
        {
            _paths = paths.ToList();
            DerivedPaths= new List<Path>();
        }

        public List<Path> DerivePaths(IPosition currentPosition, Tilemap tilemap, TileObject thisObject)
        {

            return DerivedPaths;
        }

        public void DerivePath(Position currentPosition, Tilemap tilemap, Path path, TileObject thisObject)
        {
            for(int i = 0; i < path.Count; i++)
            {
                Tile tile = tilemap[currentPosition + (Position)path[i]];
                foreach(var con in MoveConditions)
                {
                    con.Condition(tile, thisObject);
                    con.Action(path, i);
                }
            }
        }

    }

    /// <summary>
    /// A struct that contains a condition and action for a specific Tile/Tile Object affect on a path.
    /// </summary>
    public struct MoveCondition
    {

        public Func<Tile, TileObject, bool> Condition;
        public Action<Path, int> Action;

        /// <summary>
        /// A struct that contains a condition and action for a specific Tile/Tile Object affect on a path.
        /// </summary>
        /// <param name="condition">The Condition - A Function that determines whether to take an action based on the Tile in the path and the TileObject that path belongs to.</param>
        /// <param name="action">An action on the path if the condition is true; Highly recommended to use a method from PathMaker.</param>
        public MoveCondition(Func<Tile, TileObject, bool> condition, Action<Path, int> action)
        {
            Condition = condition;
            Action = action;
        }

    }

}
