
namespace ChessDemo
{
    public class Rook : ChessPiece
    {

        public Rook(IPosition position, int ownedBy) : base(position, ownedBy)
        {

        }

        public static Rook Create(IPosition position, bool isWhite)
        {
            Rook rook = new Rook(position, isWhite ? 0 : 1);

            rook.Renderer = new TOConsoleRenderer('R', isWhite ? WHITE_FOREGROUND : BLACK_FOREGROUND, isWhite ? WHITE_BACKGROUND : BLACK_BACKGROUND, true);

            var paths = PathMaker.OrthogonalAll(7);
            rook.Movement.Paths = paths.ToList();

            return rook;
        }

    }
}
