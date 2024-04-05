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




        protected ChessPiece(int ownedBy) : base(ownedBy)
        {
        }

        protected virtual void SetMovementCondition()
        {
            Movement.MoveConditions.Add(new MoveCondition(CheckEnemy, PathMaker.CutPathAfter));
        }
          
        public bool CheckEnemy(Tile tile)
        {
            if(tile.IsEmpty()) return false;
            return tile.TileObject.OwnedBy != this.OwnedBy;
        }      

       
    }
}
