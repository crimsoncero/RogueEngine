namespace RogueEngine.Renderer.Console
{
    public class TileObjectConsoleRenderer : TileObjectRenderer
    {

        public char Symbol { get; private set; }
        public ConsoleColor ForegroundColor { get; private set; }
        public ConsoleColor BackgroundColor { get; private set; }

        public TileObjectConsoleRenderer(char symbol, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Symbol = symbol;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }

        public void DrawTileObject()
        {
            ConsoleUtil.ChangeColor(ForegroundColor, BackgroundColor);
            System.Console.Write(Symbol);
        }
    }
}
