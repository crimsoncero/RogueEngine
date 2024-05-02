

namespace ChessDemo
{
    public class King : ChessPiece
    {

        public King(IPosition position, int ownedBy) : base(position, ownedBy)
        {

        }


        public override List<Path> DerivePaths(Tilemap tilemap)
        {
            base.DerivePaths(tilemap);

            List<Position> opponentPossibleMoves = new List<Position>();
            foreach(var tileObject in tilemap.)




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