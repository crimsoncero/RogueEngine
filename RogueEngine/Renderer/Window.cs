namespace RogueEngine.Renderer
{
    public abstract class Window
    {
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
