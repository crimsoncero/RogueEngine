namespace RogueConsoleRenderer
{
    public class TileConsoleRenderer : TileRenderer
    {
        public char LeftSymbol { get; private set; }
        public char RightSymbol { get; private set; }
        public ConsoleColor ForegroundColor { get; private set; }
        public ConsoleColor BackgroundColor { get; private set; }

        public TileConsoleRenderer(char leftSymbol, char rightSymbol, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            LeftSymbol = leftSymbol;
            RightSymbol = rightSymbol;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }



        public void DrawTileLeft()
        {
            ConsoleUtil.ChangeColor(ForegroundColor, BackgroundColor);
            Console.Write(LeftSymbol);
        }

        public void DrawTileMiddle(TOConsoleRenderer toRenderer)
        {
            if (toRenderer == null)
            {
                ConsoleUtil.ChangeColor(ForegroundColor, BackgroundColor);
                Console.Write(" ");
                return;
            }

            ConsoleColor backgroundColor;
            if (toRenderer.TransparentBackground)
                backgroundColor = BackgroundColor;
            else
                backgroundColor = toRenderer.BackgroundColor;

            ConsoleUtil.ChangeColor(toRenderer.ForegroundColor, backgroundColor);
            Console.Write(toRenderer.Symbol);
        }

        public void DrawTileRight()
        {
            ConsoleUtil.ChangeColor(ForegroundColor, BackgroundColor);
            Console.Write(RightSymbol);
        }
    }
}
