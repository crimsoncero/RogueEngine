using System.ComponentModel;
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

        public static ChessPiece CreatePawn(bool isWhite) //The Hardest
        {
            ChessPiece piece = new ChessPiece(isWhite ? 0 : 1);

            piece.Renderer = new TOConsoleRenderer('P', isWhite ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed, ConsoleColor.Black, true);

            var paths = PathMaker.OrthogonalAll(7);
            piece.Movement = new Movement(paths);

            return piece;
        }

        public static ChessPiece CreateKing(bool isWhite)
        {
            ChessPiece piece = new ChessPiece(isWhite ? 0 : 1);

            piece.Renderer = new TOConsoleRenderer('K', isWhite ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed, ConsoleColor.Black, true);

            var paths = PathMaker.EightDirectional(1);
            piece.Movement = new Movement(paths);

            return piece;
        }

        public static ChessPiece CreateQueen(bool isWhite)
        {
            ChessPiece piece = new ChessPiece(isWhite ? 0 : 1);

            piece.Renderer = new TOConsoleRenderer('Q', isWhite ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed, ConsoleColor.Black, true);

            var paths = PathMaker.EightDirectional(7);
            piece.Movement = new Movement(paths);

            return piece;
        }

        public static ChessPiece CreateBishop(bool isWhite)
        {
            ChessPiece piece = new ChessPiece(isWhite ? 0 : 1);

            piece.Renderer = new TOConsoleRenderer('B', isWhite ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed, ConsoleColor.Black, true);

            var paths = PathMaker.DiagonalAll(7);
            piece.Movement = new Movement(paths);

            return piece;
        }

        public static ChessPiece CreateKnight(bool isWhite)
        {
            ChessPiece piece = new ChessPiece(isWhite ? 0 : 1);

            piece.Renderer = new TOConsoleRenderer('N', isWhite ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed, ConsoleColor.Black, true);
            var paths = PathMaker.KnightMoves();

            piece.Movement = new Movement(paths);

            return piece;
        }

    }
}
