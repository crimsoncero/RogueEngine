
namespace RogueEngine.Commands
{
    public class HelpCommand : Command
    {
        public HelpCommand()
        {
            ComSyntext = "Help";
            ComHelp = "";
        }

        public override bool TryExecute(string input)
        {
            throw new NotImplementedException();
        }

    }
}
