using RogueEngine.Positions;

namespace RogueEngine.Renderer.Console
{
    public abstract class Window
    {
        //const char[] _border = new char[] { };
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

        public Window(Window other)
        {
            Width = other.Width;
            Height = other.Height;
            LayerOrder = other.LayerOrder;
            TopLeftAnchor = other.TopLeftAnchor;
        }

        public virtual void RenderWindow()
        {
            // Print a blank window with edges 
            /* Right Border: 221  ▌
             * Left Border:222 ▐
             * Top Border: 223 ▀
             * Bot Border: 220 ▄
             */
        }
        public override string ToString()
        {
            return $"Window [width={Width}, height={Height}, layerOrder={LayerOrder}, topLeftAnchor={TopLeftAnchor}]";
        }

        public bool Equals(Window other)
        {
            if (other == null) return false;
            return Width == other.Width && Height == other.Height && LayerOrder == other.LayerOrder && TopLeftAnchor == other.TopLeftAnchor;
        }
    }
}
