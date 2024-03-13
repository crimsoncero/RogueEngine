
namespace RogueEngine.Commands
{
    public class DeselectCommand : Command
    {
        public DeselectCommand()
        {
            ComSyntext = "Deselect";
            ComHelp = "";
        }

        public override bool TryExecute(string input)
        {
            throw new NotImplementedException();
        }

    }
}
