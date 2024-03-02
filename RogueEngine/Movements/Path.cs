
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

        private Path(Position vector)
        {
            // Takes an orthagonal (0,y)/(x,0) or diagonal (x,x) vectors and create a linear path from it.
            _points = Subdivide(vector);
        }

        private Path(IEnumerable<Path> paths)
        {
            // Takes an Enumerable collection of paths and concats them in order to create one complex path.
            throw new NotImplementedException();
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
            while (current != vector); //Super unsafe, but its only being used with factory methods created specificly for this and checked.

            return positions;

        }

        private void ConcatPaths(Path path)
        {
            throw new NotImplementedException();
        }


        #region Base Paths Factory Methods

        public static Path Create(PathDirections direction, int length)
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


        #endregion

    }
}
