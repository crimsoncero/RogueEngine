using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDemo
{
    internal class ChessTile : Tile
    {
        public ChessTile(TileObject tileObject, IPosition position, int ownedBy) : base(tileObject, position, ownedBy)
        {
        }
    }
}
