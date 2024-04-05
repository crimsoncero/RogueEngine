
namespace ChessDemo
{
    public class Chessboard : Tilemap
    {
        public Chessboard() : base(8, 8)
        {
            // THIS IS ONLY TEMPORARY FOR CHECKING THE GAME WINDOW RENDERER. THIS IS NOT RELEVENT
            var BlackTile = new ChessTile(null, Position.ZERO, -1);
            BlackTile.Renderer = new TileConsoleRenderer(' ', ' ', ConsoleColor.White, ConsoleColor.DarkGray);
            var WhiteTile = new ChessTile(null, Position.ZERO, -1);
            WhiteTile.Renderer = new TileConsoleRenderer(' ', ' ', ConsoleColor.White, ConsoleColor.White);

            //var RookB = new Rook();
            //var RookR = new Rook();
            //var KnightB = new Rook();
            //var KnightR = new Rook();
            //var BishopB = new Rook();
            //var BishopR = new Rook();
            //var QueenB = new Rook();
            //var QueenR = new Rook();
            //var KingB = new Rook();
            //var KingR = new Rook();
            //var PawnB = new Rook();
            //var PawnR = new Rook();

            //RookB.Renderer = new TOConsoleRenderer('R', ConsoleColor.DarkCyan, ConsoleColor.Black, true);
            //RookR.Renderer = new TOConsoleRenderer('R', ConsoleColor.DarkRed, ConsoleColor.Black, true);
            //KnightB.Renderer = new TOConsoleRenderer('N', ConsoleColor.DarkCyan, ConsoleColor.Black, true);
            //KnightR.Renderer = new TOConsoleRenderer('N', ConsoleColor.DarkRed, ConsoleColor.Black, true);
            //BishopB.Renderer = new TOConsoleRenderer('B', ConsoleColor.DarkCyan, ConsoleColor.Black, true);
            //BishopR.Renderer = new TOConsoleRenderer('B', ConsoleColor.DarkRed, ConsoleColor.Black, true);
            //QueenB.Renderer = new TOConsoleRenderer('Q', ConsoleColor.DarkCyan, ConsoleColor.Black, true);
            //QueenR.Renderer = new TOConsoleRenderer('Q', ConsoleColor.DarkRed, ConsoleColor.Black, true);
            //KingB.Renderer = new TOConsoleRenderer('K', ConsoleColor.DarkCyan, ConsoleColor.Black, true);
            //KingR.Renderer = new TOConsoleRenderer('K', ConsoleColor.DarkRed, ConsoleColor.Black, true);
            //PawnB.Renderer = new TOConsoleRenderer('P', ConsoleColor.DarkCyan, ConsoleColor.Black, true);
            //PawnR.Renderer = new TOConsoleRenderer('P', ConsoleColor.DarkRed, ConsoleColor.Black, true);




            //for (int i = 0; i < Height; i++)
            //{
            //    for( int j = 0; j < Width; j++)
            //    {
            //        if(i % 2 == 0)
            //        {
            //            this[i, j] = j % 2 == 0 ? BlackTile : WhiteTile;
            //        }
            //        else
            //        {
            //            this[i, j] = j % 2 != 0 ? BlackTile : WhiteTile;
            //        }

            //        if (i == 0)
            //        {
            //            switch (j)
            //            {
            //                case 0:
            //                    this[i, j].TileObject = RookB; break;
            //                case 1:
            //                    this[i, j].TileObject = KnightB; break;
            //                case 2:
            //                    this[i, j].TileObject = BishopB; break;
            //                case 3:
            //                    this[i, j].TileObject = QueenB; break;
            //                case 4:
            //                    this[i, j].TileObject = KingB; break;
            //                case 5:
            //                    this[i, j].TileObject = BishopB; break;
            //                case 6:
            //                    this[i, j].TileObject = KnightB; break;
            //                case 7:
            //                    this[i, j].TileObject = RookB; break;
            //            }
            //        }
            //        else if (i == 7)
            //        {
            //            switch (j)
            //            {
            //                case 0:
            //                    this[i, j].TileObject = RookR; break;
            //                case 1:
            //                    this[i, j].TileObject = KnightR; break;
            //                case 2:
            //                    this[i, j].TileObject = BishopR; break;
            //                case 3:
            //                    this[i, j].TileObject = QueenR; break;
            //                case 4:
            //                    this[i, j].TileObject = KingR; break;
            //                case 5:
            //                    this[i, j].TileObject = BishopR; break;
            //                case 6:
            //                    this[i, j].TileObject = KnightR; break;
            //                case 7:
            //                    this[i, j].TileObject = RookR; break;
            //            }
            //        }
            //        else if (i == 1 || i == 6)
            //        {
            //            this[i, j].TileObject = i == 1 ? PawnB : PawnR;
            //        }
            //    }
            //}
        }
    }
}
