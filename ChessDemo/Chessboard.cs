
namespace ChessDemo
{
    public class Chessboard : Tilemap
    {
        public Chessboard() : base(8, 8)
        {
            
        }

        public override void Init()
        {
            bool isWhite = true;
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    this[i,j] = new ChessTile(null, new Position(i,j), isWhite);
                    isWhite = !isWhite;
                    this[i,j].TileObject = InitChessPiece(i, j);
                    this[i,j].TileObject.Position = this[i,j].Position;
                }

                isWhite = !isWhite;
            }
            
        }


        private ChessPiece InitChessPiece(int x, int y)
        {
            if(y == 1 || y == 6)
            {
                int ownedBy = y == 1 ? 0 : 1;
                return new Pawn(ownedBy);
            }

            if(y == 0 || y == 7)
            {
                int ownedBy = y == 0 ? 0 : 1;

                switch (x)
                {
                    case 0: 
                        return new Rook(ownedBy);
                    case 1: 
                        return new Knight(ownedBy);
                    case 2:
                        return new Bishop(ownedBy);
                    case 3:
                        return new Queen(ownedBy);
                    case 4:
                        return new King(ownedBy);
                    case 5:
                        return new Bishop(ownedBy);
                    case 6:
                        return new Knight(ownedBy);
                    case 7:
                        return new Rook(ownedBy);
                }
            }

            return null;

        }

    }
}
