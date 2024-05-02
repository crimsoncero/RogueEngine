using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ChessDemo
{
    public abstract class ChessPiece : TileObject
    {
        protected static readonly ConsoleColor WHITE_FOREGROUND = ConsoleColor.DarkBlue;
        protected static readonly ConsoleColor BLACK_FOREGROUND = ConsoleColor.DarkRed;
        protected static readonly ConsoleColor WHITE_BACKGROUND = ConsoleColor.Black;
        protected static readonly ConsoleColor BLACK_BACKGROUND = ConsoleColor.Black;




        protected ChessPiece(IPosition position, int ownedBy) : base(position, ownedBy)
        {
        }

        protected override void SetMovementConditions()
        {
            Pathfinding.MoveConditions.Add(new MoveCondition(CheckToCutAfter, PathMaker.CutPathAfter));
            Pathfinding.MoveConditions.Add(new MoveCondition(CheckToCutFrom, PathMaker.CutPathFrom));
        }


        public virtual bool CheckToCutAfter(Tile tile)
        {
            if(tile.IsEmpty) return false;
            return tile.TileObject.OwnedBy != this.OwnedBy;
        }
        
        public virtual bool CheckToCutFrom(Tile tile)
        {
            if(tile.IsEmpty) return false;
            return tile.TileObject.OwnedBy == this.OwnedBy;
        }

       
    }
}
