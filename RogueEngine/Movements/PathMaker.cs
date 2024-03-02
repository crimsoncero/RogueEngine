
namespace RogueEngine.Movements
{
    /// <summary>
    /// A Static utility class to help create more complicated Path Collections.
    /// </summary>
    public class PathMaker
    {
        public static Path Linear(PathDirections direction, int length)
        {
            return Path.Create(direction, length);
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
