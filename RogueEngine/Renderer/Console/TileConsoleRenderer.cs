
namespace RogueEngine.Renderer.Console
{
    public class TileConsoleRenderer : TileRenderer
    {
        public char LeftSymbol { get; private set; }
        public char RightSymbol { get; private set; }
        public ConsoleColor ForegroundColor { get; private set; }
        public ConsoleColor BackgroundColor { get; private set; }


        public void RenderTileLeft()
        {
            ConsoleUtil.ChangeColor(ForegroundColor, BackgroundColor);
            System.Console.Write(LeftSymbol);
        }

        public void RenderTileRight()
        {
            ConsoleUtil.ChangeColor(ForegroundColor, BackgroundColor);
            System.Console.Write(RightSymbol);
        }
    }
}
