

namespace RogueEngine.Movements
{
    public class Movement
    {
        public List<Path> Paths { get; set; }
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

        public Movement()
        {
            Paths = new List<Path>();
            DerivedPaths = new List<Path>();
            MoveConditions = new List<MoveCondition>();
        }

        public Movement(ICollection<Path> paths)
        {
            Paths = paths.ToList();
            DerivedPaths = new List<Path>();
        }

        public Path FindPathTo(IPosition pos)
        {

            Path path = DerivedPaths.Find((p) => p.Contains(new Position(pos)));
            if (path == null) return null;
            path = (Path)path.Clone();
            int index = path.IndexOf(new Position(pos));

            PathMaker.CutPathAfter(path, index);
            return path;
        }

        public List<Path> DerivePaths(Position currentPosition, Tilemap tilemap, TileObject thisObject)
        {
            DerivedPaths = new List<Path>();
            
            foreach (var path in Paths)
            {
                DerivedPaths.Add((Path)path.Clone()); 
            }
            foreach(var path in DerivedPaths)
            {
                DerivePath(currentPosition, tilemap, path);
            }

            return DerivedPaths;
        }

        private void DerivePath(Position currentPosition, Tilemap tilemap, Path path)
        {

            if (EndOnly)
            {
                // OOB Check
                var finalPos = currentPosition + (Position)path.Last;
                if (!tilemap.IsValidPosition(finalPos))
                {
                    path.Clear();
                    return;
                }

                path.KeepOnlyLast();
                Tile tile = tilemap[finalPos];
                foreach (var con in MoveConditions)
                {
                    if (con.TryExecute(tile, path, path.Count - 1))
                        if (!MultipleAlterations)
                            break;
                }
                return;
            }

            for(int i = 0; i < path.Count; i++)
            {
                // OOB Check
                var finalPos = currentPosition + (Position)path[i];
                if (!tilemap.IsValidPosition(finalPos))
                {
                    path.Clear();
                    break;
                }

                Tile tile = tilemap[finalPos];
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
