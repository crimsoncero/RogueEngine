
namespace RogueEngine.Commands
{
    public class DeselectCommand : Command
    {
        public DeselectCommand()
        {
            ComSyntext = "Deselect";
            ComHelp = "Deselect: Cancels the previous selection.";
        }

        public override bool TryExecute(string[] input, Game game)
        {
            throw new NotImplementedException();
        }

    }
}
