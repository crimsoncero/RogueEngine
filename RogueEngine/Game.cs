namespace RogueEngine
{
    public class Game<T> where T : IRenderer, new()
    {

        public T Renderer { get; set; }
        public CommandHandler CommandHandler { get; set; }

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

        private Game()
        {
            CommandHandler = new CommandHandler(Tilemap);
        }


        public void Start()
        {
            if(Tilemap == null)
            {
                throw new Exception("You must set the tilemap for the game");
            }

            Tilemap.Init();

            // Call Update 
            int endRes = EndCondition.Invoke(Tilemap);

            // REPEAT OR EXIT

        }


        private void Update()
        {
            Renderer.Render(Tilemap);

            bool hasExecuted = CommandHandler.AwaitCommand();

            // Update Game state according to command
           
        }

        public static Game<T> Create()
        {
            var game = new Game<T>();
            game.Renderer = new T();

            return game;
        }

    }
}