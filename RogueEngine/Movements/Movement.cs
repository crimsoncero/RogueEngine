

namespace RogueEngine.Movements
{
    public class Movement
    {
        private List<Path> _paths;
        public List<Path> DerivedPaths { get; private set; }
        public List<MoveCondition> MoveConditions { get; set; }
        
        /// <summary>
        /// Whether only the end points count for the Derived Path matter, and as such no check for points along the way will be done.
        /// </summary>
        public bool EndOnly { get; set; } = false;
        /// <summary>
        /// Whether a path can be altered by multiple conditions at the same time.
        /// </summary>
        public bool MultipleAlterations { get; set; } = false;
        
        
        public Movement(ICollection<Path> paths)
        {
            _paths = paths.ToList();
            DerivedPaths= new List<Path>();
        }

        public List<Path> DerivePaths(IPosition currentPosition, Tilemap tilemap, TileObject thisObject)
        {

            return DerivedPaths;
        }

        public void DerivePath(Position currentPosition, Tilemap tilemap, Path path)
        {
            for(int i = 0; i < path.Count; i++)
            {
                Tile tile = tilemap[currentPosition + (Position)path[i]];
                foreach(var con in MoveConditions)
                {
                    if (con.TryExecute(tile, path, i))
                        if(!MultipleAlterations)
                            break;
                }
            }
        }

    }

    /// <summary>
    /// A struct that contains a condition and action for a specific Tile/Tile Object affect on a path.
    /// </summary>
    public struct MoveCondition
    {

        public Predicate<Tile> Condition;
        public Action<Path, int> Action;

        /// <summary>
        /// A struct that contains a condition and action for a specific Tile/Tile Object affect on a path.
        /// </summary>
        /// <param name="condition">The Condition - A Function that determines whether to take an action based on the Tile in the path and the TileObject that path belongs to.</param>
        /// <param name="action">An action on the path if the condition is true; Highly recommended to use a method from PathMaker.</param>
        public MoveCondition(Predicate<Tile> condition, Action<Path, int> action)
        {
            Condition = condition;
            Action = action;
        }

        /// <summary>
        /// Tries to execute the conditional action.
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="path"></param>
        /// <param name="position"></param>
        /// <returns>Whether the condition was true or false, and an action was made</returns>
        public bool TryExecute(Tile tile, Path path, int position)
        {
            if(Condition(tile))
            {
                Action.Invoke(path, position);
                return true;
            }
            return false;
        }
    }

}
