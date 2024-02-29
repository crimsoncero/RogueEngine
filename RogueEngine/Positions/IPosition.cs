// Amit  //


namespace RogueEngine.Positions
{
    public interface IPosition
    {
        public int X { get; init; }
        public int Y { get; init; }


        public IPosition Add(IPosition b);
        public static IPosition operator +(IPosition a, IPosition b) => a.Add(b);
        public IPosition Subtract(IPosition b);
        public static IPosition operator -(IPosition a, IPosition b) => a.Subtract(b);
        public IPosition Multiply(int scalar);
        public static IPosition operator *(IPosition a, int scalar) => a.Multiply(scalar);
        public IPosition Divide(int divisor);
        public static IPosition operator /(IPosition a, int divisor) => a.Divide(divisor);

    }

    
}


