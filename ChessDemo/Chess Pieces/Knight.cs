


namespace ChessDemo
{
    public class Knight : ChessPiece
    {

        public Knight(int ownedBy) : base(ownedBy)
        {

        }

        public static Knight Create(bool isWhite)
        {
            Knight knight = new Knight(isWhite ? 0 : 1);

            knight.Renderer = new TOConsoleRenderer('N', isWhite ? WHITE_FOREGROUND : BLACK_FOREGROUND, isWhite ? WHITE_BACKGROUND : BLACK_BACKGROUND, true);
            var paths = KnightPaths();

            knight.Movement = new Movement(paths);
            knight.Movement.EndOnly = true;

            return knight;
        }

        private static List<Path> KnightPaths()
        {
           return new List<Path>
            {
                PathMaker.Complex(new List<(PathDirections, int)>
                {
                    (PathDirections.Up, 2), (PathDirections.Right, 1)
                }),
                PathMaker.Complex(new List<(PathDirections, int)>
                {
                    (PathDirections.Up, 2), (PathDirections.Left, 1)
                }),
                PathMaker.Complex(new List<(PathDirections, int)>
                {
                    (PathDirections.Down, 2), (PathDirections.Right, 1)
                }),
                PathMaker.Complex(new List<(PathDirections, int)>
                {
                    (PathDirections.Down, 2), (PathDirections.Left, 1)
                }),
                PathMaker.Complex(new List<(PathDirections, int)>
                {
                    (PathDirections.Right, 2), (PathDirections.Up, 1)
                }),
                PathMaker.Complex(new List<(PathDirections, int)>
                {
                    (PathDirections.Right, 2), (PathDirections.Down, 1)
                }),
                PathMaker.Complex(new List<(PathDirections, int)>
                {
                    (PathDirections.Left, 2), (PathDirections.Up, 1)
                }),
                PathMaker.Complex(new List<(PathDirections, int)>
                {
                    (PathDirections.Left, 2), (PathDirections.Down, 1)
                })
            };
        }

    }
}
