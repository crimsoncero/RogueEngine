using RogueEngine.Positions;

namespace RogueEngine.Movement
{
    public class Path
    {
        private List<Position> _pathVectors;

        public Path(IEnumerable<Position> pathVectors)
        {
            _pathVectors = new List<Position>(pathVectors);
        }
        public Path(Position[] pathVectors)
        {
            _pathVectors = new List<Position>(pathVectors);
        }

        #region Factory Paths
        public static Path UpX(int distance)
        {
            return new Path(Enumerable.Repeat(Position.UP, distance));
        }
        public static Path DownX(int distance)
        {
            return new Path(Enumerable.Repeat(Position.DOWN, distance));
        }
        public static Path LeftX(int distance)
        {
            return new Path(Enumerable.Repeat(Position.LEFT, distance));
        }
        public static Path RightX(int distance)
        {
            return new Path(Enumerable.Repeat(Position.RIGHT, distance));
        }


        #endregion

    }
}
