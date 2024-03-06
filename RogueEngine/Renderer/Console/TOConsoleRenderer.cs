namespace RogueEngine.Renderer.Console
{
    public class TOConsoleRenderer : TileObjectRenderer
    {

        public char Symbol { get; private set; }
        public ConsoleColor ForegroundColor { get; private set; }
        public ConsoleColor BackgroundColor { get; private set; }
        public bool TransparentBackground { get; private set; }

        public TOConsoleRenderer(char symbol, ConsoleColor foregroundColor, ConsoleColor backgroundColor, bool transparentBackground)
        {
            Symbol = symbol;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            TransparentBackground = transparentBackground;
        }

        public void DrawTileObject()
        {
            ConsoleUtil.ChangeColor(ForegroundColor, BackgroundColor);
            System.Console.Write(Symbol);
        }
    }
}
