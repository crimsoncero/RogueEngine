
using System.Collections;

namespace RogueEngine.Movements
{
    public enum PathDirections
    {
        Up,
        UpRight,
        Right,
        DownRight,
        Down,
        DownLeft,
        Left,
        UpLeft
    }


    /// <summary>
    /// An immutable collection of all the points in a 2D tilemap path.
    /// </summary>
    /// <typeparam name="T"> A class that implements IPosition</typeparam>
    public class Path
    {
        private List<Position> _points;
        public IPosition this[int i] { get { return _points[i]; } }
        public int Count { get { return _points.Count; } }

        private Path(Position vector)
        {
            // Takes an orthagonal (0,y)/(x,0) or diagonal (|x|,|x|) vectors and create a linear path from it.
            _points = Subdivide(vector);
        }

        private List<Position> Subdivide(Position vector)
        {
            
            if (vector == Position.ZERO)
                throw new ArgumentException("Can't create a path for vector zero");

            Position iterator = new Position(0, 0);

            bool IsDiagonal = Math.Abs(vector.X) == Math.Abs(vector.Y);
            bool IsOrthagonal = vector.X == 0 || vector.Y == 0;

            if (IsDiagonal || IsOrthagonal)
                iterator = new Position(Math.Sign(vector.X), Math.Sign(vector.Y)); 
            else
                throw new ArgumentException("vector must be either orthagonal or diagonal of the shape |x| = |y|");
            
            
            
            var positions = new List<Position>();

            Position current = Position.ZERO;
            
            do
            {
                current += iterator;
                positions.Add(current);
            }
            while (current != vector);

            return positions;

        }

        /// <summary>
        /// Joins the path given to the current path.
        /// </summary>
        /// <param name="path"> The path to concat</param>
        internal void Concat(Path path)
        {
            if (path.Count == 0)
                return; // Empty Path

            Position adjustment = _points.Last();
            for(int i = 0; i < path.Count; i++)
            {
                // Adjust the position in the joined path to the end point of the current path.
                Position newPosition =  (Position)path[i] + adjustment;
                _points.Add(newPosition);
            }
        }


        /// <summary>
        /// Create a path in the direction and length specified.
        /// </summary>
        /// <param name="direction"> The direction the path takes</param>
        /// <param name="length">The length of the path. Note: The length in diagonals is not the actual vector magnitude, but the absolute X and Y values of the final position.</param>
        /// <returns></returns>
        internal static Path Create(PathDirections direction, int length)
        {
            Position vector = Position.ZERO;

            switch (direction)
            {
                case PathDirections.Up:
                    vector = new Position(0, length);
                    break;
                case PathDirections.UpRight:
                    vector = new Position(length, length);
                    break;
                case PathDirections.Right:
                    vector = new Position(length, 0);
                    break;
                case PathDirections.DownRight:
                    vector = new Position(length, -length);
                    break;
                case PathDirections.Down:
                    vector = new Position(0, -length);
                    break;
                case PathDirections.DownLeft:
                    vector = new Position(-length, -length);
                    break;
                case PathDirections.Left:
                    vector = new Position(-length, 0);
                    break;
                case PathDirections.UpLeft:
                    vector = new Position(-length, length);
                    break;
            }

            return new Path(vector);
        }

    }
}
