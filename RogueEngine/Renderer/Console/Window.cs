
namespace RogueEngine.Renderer.Console
{
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

        }

        protected void Clear(bool clearBorder)
        {
            // Clears the window, if clearBorder is true, clears the borders as well.
        }

        public override string ToString()
        {
            return $"Window [width={Width}, height={Height}, layerOrder={LayerOrder}, topLeftAnchor={TopLeftAnchor}]";
        }
    }
}
