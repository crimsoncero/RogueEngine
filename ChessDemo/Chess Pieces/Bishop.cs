

namespace ChessDemo
{
    public class Bishop : ChessPiece
    {

        public Bishop(IPosition position, int ownedBy) : base(position, ownedBy)
        {

        }

        public static Bishop Create(IPosition position, bool isWhite)
        {
            Bishop bishop = new Bishop(position, isWhite ? 0 : 1);

            bishop.Renderer = new TOConsoleRenderer('B', isWhite ? WHITE_FOREGROUND : BLACK_FOREGROUND, isWhite ? WHITE_BACKGROUND : BLACK_BACKGROUND, true);

            var paths = PathMaker.DiagonalAll(7);
            bishop.Pathfinding.Paths = paths.ToList();

            return bishop;
        }

    }
}
