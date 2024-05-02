
namespace ChessDemo
{
    public class Chessboard : Tilemap
    {
        public King WhiteKing { get; private set; }
        public King BlackKing { get; private set; }



        public Chessboard() : base(8, 8) { }
        public override void Init()
        {
            bool isWhite = true;
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    this[j,i] = new ChessTile(null, new Position(j,i), isWhite);
                    isWhite = !isWhite;
                    this[j,i].TileObject = InitChessPiece(j, i);
                }

                isWhite = !isWhite;
            }
            
        }


        public bool CheckForCheckmate(bool checkWhite)
        {
            if (checkWhite)
                return !WhiteKing.CanMove(this);
            return !BlackKing.CanMove(this);
        }

        private ChessPiece InitChessPiece(int x, int y)
        {
            if(y == 1 || y == 6)
            {
                bool isWhite = y == 1 ? true : false;
                return Pawn.Create(new Position(x, y), isWhite);
            }

            if(y == 0 || y == 7)
            {
                bool isWhite = y == 0 ? true : false;

                switch (x)
                {
                    case 0: 
                        return Rook.Create(new Position(x, y), isWhite);
                    case 1: 
                        return Knight.Create(new Position(x, y), isWhite);
                    case 2:
                        return Bishop.Create(new Position(x, y), isWhite);
                    case 3:
                        return Queen.Create(new Position(x, y), isWhite);
                    case 4:
                        if (isWhite)
                            WhiteKing = King.Create(new Position(x, y), true);
                        else
                            BlackKing = King.Create(new Position(x, y), false);
                        return isWhite ? WhiteKing : BlackKing;
                    case 5:
                        return Bishop.Create(new Position(x, y), isWhite);
                    case 6:
                        return Knight.Create(new Position(x, y), isWhite);
                    case 7:
                        return Rook.Create(new Position(x, y), isWhite);
                }
            }

            return null;

        }

        private ChessPiece KingChecks(int x, int y)
        {
            if (x == 4 && y == 5)
            {
                BlackKing = King.Create(new Position(x, y), false);
                return BlackKing;
            }

            if (x == 1 && y == 4)
                return Rook.Create(new Position(x, y), false);

            if (x == 2 && y == 6)
                return Rook.Create(new Position(x, y), true);

            if (x == 3 && y == 2)
                return Rook.Create(new Position(x, y), true);

            if (x == 5 && y == 2)
                return Rook.Create(new Position(x, y), true);

            if (x == 6 && y == 1)
                return Rook.Create(new Position(x, y), true);

            if (x == 0 && y == 0)
            {
                WhiteKing = King.Create(new Position(x, y), true);
                return WhiteKing;
            }
                

            return null;

        }

    }
}
