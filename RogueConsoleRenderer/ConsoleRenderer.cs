//Lee

using RogueEngine;

namespace RogueConsoleRenderer
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
            TopLeftAnchor = new Position(0, 0);
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



    public class ConsoleRenderer : IRenderer, IConsole
    {
        private Window _gameScene;

        public ConsoleRenSettings Settings { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        private bool _isFirstRender = true;

        private Position _consoleStart { get { return new Position(0, Settings.TopLeftAnchor.Y + Height + 1); } }
        private string _errorText = string.Empty;
        private string _turnText = string.Empty;
        private string _helpText = string.Empty;

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
            Console.Title = Settings.GameTitle;


            Position consolePos = new Position(Console.CursorLeft, Console.CursorTop);
            if (_isFirstRender)
            {
                consolePos = _consoleStart;
                _isFirstRender = false;
            }


            _gameScene.RenderWindow();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft = consolePos.X;
            Console.CursorTop = consolePos.Y;

            if(_errorText != string.Empty)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: " + _errorText);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n------------------------------------------\n");
                _errorText= string.Empty;
            }
            if(_turnText != string.Empty)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(_turnText);
                Console.WriteLine("\n------------------------------------------\n");
                _turnText= string.Empty;
            }
            if(_helpText != string.Empty)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(_helpText);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n------------------------------------------\n");
                _helpText = string.Empty;
                
            }
            Console.ForegroundColor = ConsoleColor.White;


        }

        public void Clear()
        {
            Console.Clear();
        }

        public void ClearConsole()
        {
            Clear();
            _isFirstRender = true;
            Render();


        }

        public void WriteError(string errorText)
        {
            _errorText = errorText.Trim();
        }

        public void WriteTurn(string turnText)
        {
            _turnText = turnText.Trim();
        }

        public void WriteHelp(string helpText)
        {
            _helpText = helpText.Trim();
        }

      
    }
}

