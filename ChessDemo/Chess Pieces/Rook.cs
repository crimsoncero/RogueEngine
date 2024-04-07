
namespace ChessDemo
{
    public class Rook : ChessPiece
    {

        public Rook(int ownedBy) : base(ownedBy)
        {

        }

        public static Rook Create(bool isWhite)
        {
            Rook rook = new Rook(isWhite ? 0 : 1);

            rook.Renderer = new TOConsoleRenderer('R', isWhite ? WHITE_FOREGROUND : BLACK_FOREGROUND, isWhite ? WHITE_BACKGROUND : BLACK_BACKGROUND, true);

            var paths = PathMaker.OrthogonalAll(7);
            rook.Movement.Paths = paths.ToList();

            return rook;
        }

    }
}
