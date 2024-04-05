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
        public Func<Tilemap> InitTilemap { get; set; }
        
        private TileObject _selectedObject = null;
        private Tilemap _tilemap = null;

        private Game()
        {
            Renderer = new T();
            CommandHandler = new CommandHandler();
        }


        public void Start()
        {
            // Render

            bool hasExecuted = CommandHandler.AwaitCommand();

            // Update Game state according to command

            int endRes = EndCondition.Invoke(_tilemap);

            // REPEAT OR EXIT

        }




        public static Game<T> Create()
        {
            Game<T> game = new Game<T>();
            game.InitTilemap();

            return game;
        }
    }
}