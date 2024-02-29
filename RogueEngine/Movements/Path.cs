
using System.Collections;

namespace RogueEngine.Movements
{
    /// <summary>
    /// An immutable collection of all the points in a 2D tilemap path.
    /// </summary>
    /// <typeparam name="T"> A class that implements IPosition</typeparam>
    public class Path<T> where T : IPosition
    {
        private T[] _points;
        public ICollection<T> Points { get { return _points; } }
        public T this[int i] { get { return _points[i]; } }

        private Path(T vector)
        {
            // Takes an orthagonal (0,y)/(x,0) or diagonal (x,x) vectors and create a linear path from it.
            _points = new T[] { vector };
        }

        private Path(IEnumerable<Path<T>> paths)
        {
            // Takes an Enumerable collection of paths and concats them in order to create one complex path.
            throw new NotImplementedException();
        }

        private T[] Subdivide(T[] vectors)
        {
            // Divides a linear vector into its points.
            throw new NotImplementedException();
        }

        private void ConcatPaths(Path<T> path)
        {
            throw new NotImplementedException();
        }


        #region Base Paths Factory Methods

        public static Path<Position> Up(int length)
        {
            return new Path<Position>(new Position(0, length));
        }


        #endregion  

    }
}
