﻿
namespace RogueEngine.Commands
{
    public class CommandHandler
    {
        public List<Command> Commands { get; private set; }
        public bool ClearConsoleAfterInput = false;
        public HelpCommand Help { get; private set; }

        public Tilemap Tilemap { get; set; }

        public CommandHandler(Tilemap tilemap)
        {
            Help = new HelpCommand();
            Commands = new List<Command>() { Help };
            Tilemap = tilemap;
        }

        /// <summary>
        /// Adds a command to the list of commands in the game.
        /// </summary>
        /// <param name="command"></param>
        public void AddCommand(Command command)
        {
            if(Commands.Contains(command)) return;
            Help.ComHelpList.Add(command.ComHelp);
            Commands.Add(command);
        }

        /// <summary>
        /// Awaits for a command to be inputted, returns whether a valid command was input and executed.
        /// </summary>
        /// <returns></returns>
        public bool AwaitCommand()
        {
            // await player command input.
            string[] input = Console.ReadLine().Trim().Split(' ', ',', ';', ':', '.', '!', '?');

            if (ClearConsoleAfterInput)
            {
               throw new NotImplementedException();
            }


            // find the command.
            Command com = Commands.Find((c) => c.ComSyntext.ToLower() == input[0].ToLower());
            
            // check if the command is exist and try to execute it.
            if (com != null)
            {
                if (com.TryExecute(input, Tilemap))
                {
                    return true;
                }
            }
            else
            {
                Help.TryExecute(input, Tilemap);
            }

            return false;

        }

    }
}
