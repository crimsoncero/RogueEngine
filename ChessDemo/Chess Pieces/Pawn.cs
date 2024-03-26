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
            pawn.Movement = new Movement(paths);

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

        
    }
}
