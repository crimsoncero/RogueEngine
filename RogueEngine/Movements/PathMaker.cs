﻿
namespace RogueEngine.Movements
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

    }
}
