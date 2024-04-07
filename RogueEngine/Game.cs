namespace RogueEngine
{
    public class Game
    {

        public IRenderer Renderer { get; set; }
        public CommandHandler CommandHandler { get; set; }

        /// <summary>
        /// The condition to end the game, return the index of the winner, -1 if the game hasn't ended, or -2 in case of a tie.
        /// </summary>
        public Func<Tilemap, int> EndCondition { get; set; }
        
       
        public Tilemap Tilemap { get; set; } = null;

        private Game()
        {
            CommandHandler = new CommandHandler(this);
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
            // Render

            bool hasExecuted = CommandHandler.AwaitCommand();

            // Update Game state according to command
           
        }

        public static Game CreateConsoleGame()
        {
            Game game = new Game();
            game.Renderer = new ConsoleRenderer();

            return game;
        }

    }
}