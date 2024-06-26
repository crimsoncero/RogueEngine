﻿
namespace RogueEngine.Pathing
{
    /// <summary>
    /// A Static utility class to create more complicated Path Collections.
    /// </summary>
    public static class PathMaker
    {
        public static Path Linear(PathDirections direction, int length)
        {
            if (length <= 0)
                return null;
            
            return Path.Create(direction, length);
        }

        /// <summary>
        /// Create a complex path by giving a set of directions and lengths.
        /// </summary>
        /// <param name="pathDirections"></param>
        /// <returns></returns>
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
            var paths = new List<Path>
            {
                Linear(PathDirections.Up, length),
                Linear(PathDirections.UpRight, length),
                Linear(PathDirections.Right, length),
                Linear(PathDirections.DownRight, length),
                Linear(PathDirections.Down, length),
                Linear(PathDirections.DownLeft, length),
                Linear(PathDirections.Left, length),
                Linear(PathDirections.UpLeft, length)
            };
            return paths;
        }

        public static ICollection<Path> OrthogonalAll(int length)
        {
            var paths = new List<Path>
            {
                Linear(PathDirections.Up, length),
                Linear(PathDirections.Right, length),
                Linear(PathDirections.Down, length),
                Linear(PathDirections.Left, length)
            };
            return paths;
        }

        public static ICollection<Path> DiagonalAll(int length)
        {
            var paths = new List<Path>
            {
                Linear(PathDirections.UpRight, length),
                Linear(PathDirections.DownRight, length),
                Linear(PathDirections.DownLeft, length),
                Linear(PathDirections.UpLeft, length)
            };
            return paths;
        }

        public static ICollection<Path> DiagonalUp(int length)
        {
            var paths = new List<Path>
            {
                Linear(PathDirections.UpRight, length),
                Linear(PathDirections.UpLeft, length)
            };
            return paths;
        }

        public static ICollection<Path> DiagonalDown(int length)
        {
            var paths = new List<Path>
            {
                Linear(PathDirections.DownRight, length),
                Linear(PathDirections.DownLeft, length)
            };
            return paths;
        }
        /// <summary>
        /// Cuts the given path from the point after the given index.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="index"></param>
        public static void CutPathAfter(Path path, int index)
        {
            for(int i = path.Count - 1; i > index; i--)
            {
                path.RemoveLast();
            }           
        }

        /// <summary>
        /// Cuts the given path from the point of the index, included.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="index"></param>
        public static void CutPathFrom(Path path, int index)
        {
            for (int i = path.Count; i > index; i--)
            {
                path.RemoveLast();
            }
        }
                       

    }
}
