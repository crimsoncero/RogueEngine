using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDemo
{
    internal class ChessTile : Tile
    {
        public ChessTile(TileObject tileObject, IPosition position, bool isWhite) : base(tileObject, position, -1)
        {
            Renderer = new TileConsoleRenderer(' ', ' ', ConsoleColor.White, isWhite? ConsoleColor.White : ConsoleColor.DarkGray);


        }
    }
}
