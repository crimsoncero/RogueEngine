
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

        public Path(List<T> list)
        {
            _points = list.ToArray();
        }

        private T[] Subdivide(T[] vectors)
        {
            throw new NotImplementedException();
        }

        private void ConcatPaths(Path<T> path)
        {
            throw new NotImplementedException();
        }


    }
}
