
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

namespace RogueEngine.Position
{
    public readonly struct Position : IPosition
    {
        public int X { get; init; }
        public int Y { get; init; }

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
