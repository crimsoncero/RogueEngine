//Lee


namespace RogueEngine.Renderer.Console
{
    using System;
    public abstract class Window
    {
        private const char BORDER_TOP = '▀';
        private const char BORDER_BOTTOM = '▄';
        private const char BORDER_LEFT = '▌';
        private const char BORDER_RIGHT = '▐';



        public int Width { get; set; }
        public int Height { get; set; }
        public int LayerOrder { get; set; }
        public IPosition TopLeftAnchor { get; set; }

        public Window(int width, int height, int layerOrder, IPosition topLeftAnchor)
        {
            Width = width;
            Height = height;
            LayerOrder = layerOrder;
            TopLeftAnchor = topLeftAnchor;
        }

        public virtual void RenderWindow()
        {
            DrawBorder();

        }

        protected virtual void DrawBorder()
        {
            char topBorder = '▀', bottomBorder = '▄', leftBorder = '▐', rightBorder = '▌';
            string topBottomRow = topBorder.ToString().PadRight(Width - 1, topBorder) + topBorder;
            string middleRow = leftBorder + new string(' ', Width - 2) + rightBorder;

            Console.WriteLine(topBottomRow); // Top border
            for (int i = 1; i < Height - 1; i++)
            {
                Console.WriteLine(middleRow); // Middle rows
            }
            Console.WriteLine(bottomBorder); // Bottom border
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
            return $"Window [width={Width}, height={Height}, layerOrder={LayerOrder}, topLeftAnchor={TopLeftAnchor}]";
        }
    }
}
