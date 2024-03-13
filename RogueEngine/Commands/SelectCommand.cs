
namespace RogueEngine.Commands
{
    public class SelectCommand : Command
    {
        public SelectCommand()
        {
            ComSyntext = "Select";
            ComHelp = "";
        }

        public override bool TryExecute(string input)
        {
            throw new NotImplementedException();
        }
    }
}
