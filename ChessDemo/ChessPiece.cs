using Path = RogueEngine.Movements.Path;

namespace ChessDemo
{
    class ChessPiece : TileObject
    {
        private ChessPiece(int ownedBy) : base(ownedBy)
        {
        }

     


        public static ChessPiece CreateRook(bool isWhite)
        {
            ChessPiece piece = new ChessPiece(isWhite ? 0 : 1);
            
            piece.Renderer = new TOConsoleRenderer('R', isWhite ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed, ConsoleColor.Black, true);

            var paths = PathMaker.OrthogonalAll(7);
            piece.Movement = new Movement(paths);

            return piece;
        }

    }
}
