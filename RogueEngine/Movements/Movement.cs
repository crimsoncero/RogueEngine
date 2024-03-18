

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

        public List<Path> DerivePaths(IPosition currentPosition, Tilemap tilemap)
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
                    con.Predicate(tile);
                    con.Action(path, i);
                }
            }
        }

    }

    public struct MoveCondition
    {
        public Predicate<Tile> Predicate;
        public Action<Path, int> Action;

    }

}
