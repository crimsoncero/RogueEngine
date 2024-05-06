namespace RogueEngine
{
    public class GameSettings
    {
        public string Name {  get; set; }
        public uint PlayerCount { get; set; }

        public GameSettings()
        {
            Name = "A Rogue Engine Game";
            PlayerCount = 2;
        }

    }


    public class Game<T> where T : IRenderer, new()
    {

        public GameSettings Settings { get; set; }
        public T Renderer { get; set; }
        public IConsole _console;
        public IConsole Console
        {
            get { return _console; }
            set 
            {
                _console = value;
                CommandHandler.Settings.Console = _console;
            }
        }
        public CommandHandler<T> CommandHandler { get; set; }

        /// <summary>
        /// The condition to end the game, return the index of the winner, -1 if the game hasn't ended, or -2 in case of a tie.
        /// </summary>
        public Func<Tilemap, int> EndCondition { get; set; }

        private Tilemap _tilemap = null;
        public Tilemap Tilemap
        {
            get
            {
                return _tilemap;
            }
            set
            {
                _tilemap = value;
                CommandHandler.Tilemap = _tilemap;
            }
        }

        public int CurrentPlayer { get; private set; }

        private Game()
        {
            Settings = new GameSettings();
            CommandHandler = new CommandHandler<T>(Tilemap, this);
        }


        public void Start()
        {
            if(Tilemap == null)
            {
                throw new Exception("You must set the tilemap for the game");
            }

            Tilemap.Init();
            int endRes = -1;
            while (endRes == -1)
            {
                Update();
                endRes = EndCondition.Invoke(Tilemap);
            }
            Renderer.Render();
            

        }

        public void AdvanceTurn()
        {
            CurrentPlayer++;
            if(CurrentPlayer >= Settings.PlayerCount) CurrentPlayer = 0;
        }


        private void Update()
        {
            Console.WriteTurn($"Player {CurrentPlayer + 1} Turn:");
            Renderer.Render();

            bool hasExecuted = CommandHandler.AwaitCommand();
           
        }

        public static Game<T> Create()
        {
            var game = new Game<T>();
            game.Renderer = new T();
            return game;
        }


    }
}