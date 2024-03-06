
namespace RogueEngine.Renderer.Console
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

        public void DrawTile()
        {
            DrawTileLeft();

            DrawTileRight();
        }

        public void DrawTileLeft()
        {
            ConsoleUtil.ChangeColor(ForegroundColor, BackgroundColor);
            System.Console.Write(LeftSymbol);
        }

        public void DrawTileRight()
        {
            ConsoleUtil.ChangeColor(ForegroundColor, BackgroundColor);
            System.Console.Write(RightSymbol);
        }
    }
}
