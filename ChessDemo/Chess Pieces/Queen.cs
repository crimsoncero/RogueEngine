

namespace ChessDemo
{
    public class Queen : ChessPiece
    {

        public Queen(int ownedBy) : base(ownedBy)
        {

        }

        public static Queen CreateQueen(bool isWhite)
        {
            Queen queen = new Queen(isWhite ? 0 : 1);

            queen.Renderer = new TOConsoleRenderer('Q', isWhite ? WHITE_FOREGROUND : BLACK_FOREGROUND, isWhite ? WHITE_BACKGROUND : BLACK_BACKGROUND, true);

            var paths = PathMaker.EightDirectional(7);
            queen.Movement.Paths = paths.ToList();

            return queen;
        }
    }
}