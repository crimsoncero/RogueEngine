//Lee


namespace RogueEngine.Renderer.Console
{

    public class ConsoleRenSettings
    {
        public Position TopLeftAnchor { get; set; }
        public TileConsoleRenderer DefaultTileRenderer { get; set; }
        public TOConsoleRenderer DefaultTORenderer { get; set; }

        // default border characters props



        public ConsoleRenSettings()
        {
            // make default settings for the renderer.
            throw new NotImplementedException();
        }
    }



    public class ConsoleRenderer : IRenderer
    {
        private List<Window> _gameScene;

        public ConsoleRenSettings Settings { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        



        public ConsoleRenderer()
        {
            _gameScene = new List<Window>();
        }

        public void AddWindow(Window window)
        {
            // increase height and width according to the window added.
            _gameScene.Add(window);
            window.Settings = Settings;
        }

        public void Render(Tilemap tilemap)
        {
            foreach(var window in _gameScene)
            {
                window.RenderWindow();
            }

        }

        public static IRenderer Create()
        {
            throw new NotImplementedException();
        }
    }
}

