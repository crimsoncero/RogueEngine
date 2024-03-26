

namespace ChessDemo
{
    public class Bishop : ChessPiece
    {

        public Bishop(int ownedBy) : base(ownedBy)
        {

        }

        public static Bishop Create(bool isWhite)
        {
            Bishop bishop = new Bishop(isWhite ? 0 : 1);

            bishop.Renderer = new TOConsoleRenderer('B', isWhite ? WHITE_FOREGROUND : BLACK_FOREGROUND, isWhite ? WHITE_BACKGROUND : BLACK_BACKGROUND, true);

            var paths = PathMaker.DiagonalAll(7);
            bishop.Movement = new Movement(paths);

            return bishop;
        }

    }
}
