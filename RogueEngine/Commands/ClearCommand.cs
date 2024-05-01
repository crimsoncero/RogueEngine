

namespace RogueEngine.Commands
{
    public class ClearCommand : Command
    {
        public ClearCommand()
        {
            ComSyntext = "Clear";
            ComHelp = "Clear: Clears the console window.";
        }

        public override bool TryExecute(string[] input, Tilemap tilemap, int c)
        {
            return true;
        }
    }
}
