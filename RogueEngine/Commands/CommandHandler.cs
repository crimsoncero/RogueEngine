
namespace RogueEngine.Commands
{


    public class CommandSettings
    {
        /// <summary>
        /// What values the user inputs for Rows.
        /// </summary>
        public char[] RowParse { get; set; }
        /// <summary>
        /// What values the user inputs for Columns.
        /// </summary>
        public char[] ColumnParse { get; set; }
        /// <summary>
        /// Is the command syntext case sensitive?
        /// </summary>
        public bool CaseSensitiveCommands { get; set; }
        /// <summary>
        /// Are the command arguments case sensitive?
        /// </summary>
        public bool CaseSensitiveArgs { get; set; }

        /// <summary>
        /// What is the list of seperators to use to split the command input.
        /// </summary>
        public char[] Seperators {  get; set; }

        /// <summary>
        /// Clear Console Automatically after input.
        /// </summary>
        public bool ClearConsoleAfterInput = false;


        public CommandSettings()
        {
            RowParse = null;
            ColumnParse = null;
            CaseSensitiveCommands = false;
            CaseSensitiveArgs = false;
            Seperators = new char[] { ' ', ',', ';', ':', '.', '!', '?' };
            ClearConsoleAfterInput = true;
        }
    }


    public class CommandHandler<T> where T : IRenderer, new()
    {
        public List<Command> Commands { get; private set; }
        public HelpCommand Help { get; private set; }
        public Tilemap Tilemap { get; set; }
        public CommandSettings Settings { get; set; }


        private readonly Game<T> _game;


        public CommandHandler(Tilemap tilemap, Game<T> game)
        {
            Settings = new CommandSettings();
            Help = new HelpCommand();
            Help.Settings = Settings;
            Commands = new List<Command>() { Help };
            AddCommand(new ClearCommand());
            Tilemap = tilemap;
            _game = game;
        }

        /// <summary>
        /// Adds a command to the list of commands in the game.
        /// </summary>
        /// <param name="command"></param>
        public void AddCommand(Command command)
        {
            if(Commands.Contains(command)) return;
            Help.ComHelpList.Add(command.ComHelp);
            command.Settings = Settings;
            Commands.Add(command);
        }

        /// <summary>
        /// Awaits for a command to be inputted, returns whether a valid command was input and executed.
        /// </summary>
        /// <returns></returns>
        public bool AwaitCommand()
        {
            // await player command input.
            string[] input = Console.ReadLine().Trim().Split(Settings.Seperators);

            if (Settings.ClearConsoleAfterInput)
            {
                _game.Renderer.ClearConsole();
            }


            // find the command.
            Command com = null;
            if (Settings.CaseSensitiveCommands)
                com = Commands.Find((c) => c.ComSyntext == input[0]);
            else
                com = Commands.Find((c) => c.ComSyntext.ToLower() == input[0].ToLower());

            // check if the command is exist and try to execute it.
            if (com != null)
            {
                if(com is ClearCommand)
                {
                    _game.Renderer.ClearConsole();
                    return true;
                }

                if (com.TryExecute(input, Tilemap, _game.CurrentPlayer))
                {
                    if (com.AdvanceTurn) _game.AdvanceTurn();
                    return true;
                }
            }
            else
            {
                Help.TryExecute(input, Tilemap, _game.CurrentPlayer);
            }

            return false;

        }

    }
}
