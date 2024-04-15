//Lee


namespace RogueEngine.Renderer.Console
{

    public class ConsoleRenSettings
    {
        public string GameTitle { get; set; }
        public Position TopLeftAnchor { get; set; }
        public TileConsoleRenderer DefaultTileRenderer { get; set; }
        public TOConsoleRenderer DefaultTORenderer { get; set; }

        public TileConsoleRenderer MoveTileRenderer { get; set; }
        public TileConsoleRenderer SelectedTileRenderer { get; set; }

        public char TopBorder { get; set; }
        public char LeftBorder { get; set; }
        public char RightBorder { get; set; }
        public char BottomBorder { get; set; }

        public ConsoleRenSettings()
        {
            GameTitle = "A Rogue Engine Game";
            TopLeftAnchor= new Position(0, 0);
            DefaultTileRenderer = new TileConsoleRenderer(' ', ' ', ConsoleColor.White, ConsoleColor.Magenta);
            DefaultTORenderer = new TOConsoleRenderer('¿', ConsoleColor.White, ConsoleColor.Magenta, false);
            MoveTileRenderer = new TileConsoleRenderer(' ', ' ', ConsoleColor.White, ConsoleColor.Yellow);
            SelectedTileRenderer = new TileConsoleRenderer('<', '>', ConsoleColor.White, ConsoleColor.DarkYellow);
            TopBorder = '▄';
            LeftBorder = '▐';
            RightBorder = '▌';
            BottomBorder = '▀';
        }
    }



    public class ConsoleRenderer : IRenderer
    {
        private Window _gameScene;

        public ConsoleRenSettings Settings { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        private bool _isFirstRender = true;

        private Position _consoleStart { get { return new Position(0, Settings.TopLeftAnchor.Y + Height + 1); } }



        public ConsoleRenderer()
        {
            Settings = new ConsoleRenSettings();
        }

        public void AddWindow(Window window)
        {
            _gameScene = window;
            Width = window.Width;
            Height = window.Height;
            window.Settings = Settings;
        }

        public void Render()
        {
            System.Console.Title = Settings.GameTitle;


            Position consolePos = new Position(System.Console.CursorLeft, System.Console.CursorTop);
            if (_isFirstRender)
            {
                consolePos = _consoleStart;
                _isFirstRender = false;
            }


            _gameScene.RenderWindow();

            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.CursorLeft = consolePos.X;
            System.Console.CursorTop = consolePos.Y;
        }

        public void ClearAll()
        {
            System.Console.Clear();
        }

        public void ClearConsole()
        {
            ClearAll();
            _isFirstRender = true;
            Render();


        }



    }
}

