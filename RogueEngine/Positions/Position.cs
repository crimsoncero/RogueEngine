
namespace RogueEngine.Positions
{
    public readonly struct Position : IPosition
    {
        public static readonly Position UP = new Position(0, -1);
        public static readonly Position DOWN = new Position(0, 1);
        public static readonly Position RIGHT = new Position(1, 0);
        public static readonly Position LEFT = new Position(-1, 0);

        public int X { get; init; } // Cols
        public int Y { get; init; } // Rows

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }

        public override bool Equals(object obj)
        {
            if(obj is Position other)
            {
                if (this.X == other.X && this.Y == other.Y)
                {
                    return true;
                }
            }

            return false ;
        }

        public override int GetHashCode()
        {
            return (X << 16) ^ Y;
        }


        public static Position operator +(Position a, Position b) => new Position(a.X + b.X, a.Y + b.Y);
        public static Position operator -(Position a, Position b) => new Position(a.X - b.X, a.Y - b.Y);
    }
}
