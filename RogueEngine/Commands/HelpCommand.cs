
namespace RogueEngine.Commands
{
    public class HelpCommand : Command
    {

        public List<string> ComHelpList { get; set; }

        public HelpCommand()
        {
            ComSyntext = "Help";
            ComHelp = "Help: Show all the commands in the game.";
            ComHelpList = new List<string>() { ComHelp };
        }

        public override bool TryExecute(string[] input, Game game)
        {
            foreach(string s in ComHelpList)
            {
                Console.WriteLine(s);
            }

            return true;
        }

    }
}
