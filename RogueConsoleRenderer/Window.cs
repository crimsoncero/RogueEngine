//Lee


namespace RogueConsoleRenderer
{
    using System;

    public abstract class Window
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public IPosition TopLeftAnchor { get; set; }

        public ConsoleRenSettings Settings { get; internal set; }

        public Window(int width, int height, IPosition topLeftAnchor)
        {
            Width = width;
            Height = height;
            TopLeftAnchor = topLeftAnchor;
        }

        public virtual void RenderWindow()
        {
            DrawBorder();

        }

        protected virtual void DrawBorder()
        {

            ConsoleUtil.SetCursor(TopLeftAnchor);

            string topRow = Settings.TopBorder.ToString().PadRight(Width, Settings.TopBorder);
            string middleRow = Settings.LeftBorder + new string(' ', Width - 2) + Settings.RightBorder;
            string bottomRow = Settings.BottomBorder.ToString().PadRight(Width, Settings.BottomBorder);
            Console.WriteLine(topRow); // Top border
            for (int i = 1; i < Height - 1; i++)
            {
                Console.WriteLine(middleRow); // Middle rows
            }
            Console.WriteLine(bottomRow); // Bottom border
        }

        public void ClearWindow(bool clearFrame = false)
        {
            Console.SetCursorPosition(TopLeftAnchor.X, TopLeftAnchor.Y);

            if (clearFrame)
            {
                for (int i = 0; i < Height; i++)
                {
                    Console.WriteLine(new string(' ', Width));
                }
            }
            else
            {
                for (int row = 1; row < Height - 1; row++)
                {
                    Console.SetCursorPosition(TopLeftAnchor.X + 1, TopLeftAnchor.Y + row);
                    Console.Write(new string(' ', Width - 2));
                }
            }
        }

        public override string ToString()
        {
            return $"Window [width={Width}, height={Height}, topLeftAnchor={TopLeftAnchor}]";
        }
    }


    public class EmptyWindow : Window
    {
        public EmptyWindow(int width, int height, IPosition topLeftAnchor) : base(width, height, topLeftAnchor)
        {
        }
    }
}
