

namespace ChessDemo
{
    public class King : ChessPiece
    {

        public King(IPosition position, int ownedBy) : base(position, ownedBy)
        {

        }


        public bool CheckIfCheckmated(Tilemap tilemap)
        {
            throw new NotImplementedException();
        }


        public override List<Path> DerivePaths(Tilemap tilemap)
        {
            // The King need a slightly different pathfinding pipeline, so we expand it.

            // Derive with normal path rules
            base.DerivePaths(tilemap);


            // Create a list of all the positions the opponent pieces can go to next turn.
            List<Position> opponentPossibleMoves = new List<Position>();
            foreach(var tileObject in tilemap.GetPlayerObjects(OwnedBy == 0 ? 1 : 0))
            {

                // Disregard kings, they go into infinite loop atm
                if (tileObject is King) continue;

                List<Path> paths = tileObject.DerivePaths(tilemap);
                foreach(var path in paths)
                {
                    foreach(var point in path)
                    {
                        Position mapPoint = point + new Position(tileObject.Position);
                        opponentPossibleMoves.Add(mapPoint);
                    }
                }
            }

            // Remove the paths that will put the king in checkmate.

            foreach(var path in Pathfinding.DerivedPaths)
            {
                if(path.Count == 0) continue;

                if (opponentPossibleMoves.Contains(new Position(path.Last) + new Position(this.Position)))
                    path.Clear();
            }


            return Pathfinding.DerivedPaths;
        }




        public static King Create(IPosition position, bool isWhite)
        {
            King king = new King(position, isWhite ? 0 : 1);

            king.Renderer = new TOConsoleRenderer('K', isWhite ? WHITE_FOREGROUND : BLACK_FOREGROUND, isWhite ? WHITE_BACKGROUND : BLACK_BACKGROUND, true);

            var paths = PathMaker.EightDirectional(1);
            king.Pathfinding.Paths = paths.ToList();

            return king;
        }
    }
}