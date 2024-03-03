
namespace RogueEngine.Movements
{
    /// <summary>
    /// A Static utility class to create more complicated Path Collections.
    /// </summary>
    public class PathMaker
    {
        public static Path Linear(PathDirections direction, int length)
        {
            return Path.Create(direction, length);
        }

        public static Path Complex(List<(PathDirections direction, int length)> pathDirections)
        {
            Path path = Path.Create(pathDirections[0].direction, pathDirections[0].length);

            for (int i = 1; i < pathDirections.Count; i++)
            {
                path.Concat(Path.Create(pathDirections[i].direction, pathDirections[i].length));
            }

            return path;
        }


        public static ICollection<Path> EightDirectional(int length)
        {
            throw new NotImplementedException();
        }
        public static ICollection<Path> OrthagonalAll(int length)
        {
            throw new NotImplementedException(); 
        }
        public static ICollection<Path> DiagonalAll(int length)
        {
            throw new NotImplementedException();
        }
        public static ICollection<Path> OrthagonalUp(int length)
        {
            throw new NotImplementedException();
        }
        public static ICollection<Path> OrthagonalDown(int length)
        {
            throw new NotImplementedException();
        }
        public static ICollection<Path> DiagonalUp(int length)
        {
            throw new NotImplementedException();
        }
        public static ICollection<Path> DiagonalDown(int length)
        {
            throw new NotImplementedException();
        }


    }
}
