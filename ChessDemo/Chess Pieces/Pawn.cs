
namespace ChessDemo
{
    public class Pawn : ChessPiece
    {
        public bool HasMoved 
        {
            get
            {
                int startingRow = 0;
                if(OwnedBy == 0)
                    startingRow = 1;
                if(OwnedBy == 1)
                    startingRow = 6;

                return Position.Y == startingRow;
            }
        }


        public Pawn(int ownedBy) : base(ownedBy)
        {

        }

        public static Pawn Create(bool isWhite)
        {
            Pawn pawn = new Pawn(isWhite ? 0 : 1);

            pawn.Renderer = new TOConsoleRenderer('P', isWhite ? WHITE_FOREGROUND : BLACK_FOREGROUND, isWhite ? WHITE_BACKGROUND : BLACK_BACKGROUND, true);

            var paths = PawnPaths(isWhite);
            pawn.Movement.Paths = paths;

            return pawn;
        }

        private static List<Path> PawnPaths(bool isWhite)
        {
            var paths = new List<Path>();

            paths.Add(PathMaker.Linear(isWhite ? PathDirections.Up : PathDirections.Down, 2));

            var captureDirections = isWhite
              ? new List<PathDirections> { PathDirections.UpRight, PathDirections.UpLeft }
              : new List<PathDirections> { PathDirections.DownRight, PathDirections.DownLeft };

            foreach (var direction in captureDirections)
            {
                paths.Add(PathMaker.Linear(direction, 1));
            }


            return paths;
        }

        public override bool CheckToCutAfter(Tile tile)
        {
            // Pawn has no case for cutting after;
            return false;
        }

        public override bool CheckToCutFrom(Tile tile)
        {
            // Check if at starting position and thus can take two steps:

            Position vector2 = new Position(tile.Position) - new Position(this.Position);
            int startingRow = OwnedBy == 0 ? 1 : 6; // White starts at row 1 and black starts at row 6;
            // Check if double move.
            if (Math.Abs(vector2.Y) == 2 && this.Position.Y != startingRow)
                return true;
           
            
            // Cut if there is a piece at the path ahead of the pawn.
            if(vector2.X == 0)
            {
                if (tile.TileObject != null)
                    return true; 
            }
            
            // cut if there is no enemy at the diagonal of the pawn
            if(vector2.X != 0)
            {
                if (tile.TileObject == null)
                    return true;
                else if(tile.TileObject.OwnedBy == this.OwnedBy)
                    return true;
            }

            // valid move
            return false;
        }

    }
}
