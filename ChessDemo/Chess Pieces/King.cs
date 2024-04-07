
namespace ChessDemo
{
    public class King : ChessPiece
    {

        public King(int ownedBy) : base(ownedBy)
        {

        }


        public static King Create(bool isWhite)
        {
            King king = new King(isWhite ? 0 : 1);

            king.Renderer = new TOConsoleRenderer('K', isWhite ? WHITE_FOREGROUND : BLACK_FOREGROUND, isWhite ? WHITE_BACKGROUND : BLACK_BACKGROUND, true);

            var paths = PathMaker.EightDirectional(1);
            king.Movement.Paths = paths.ToList();

            return king;
        }
    }
}