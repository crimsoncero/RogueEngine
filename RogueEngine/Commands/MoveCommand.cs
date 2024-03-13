
namespace RogueEngine.Commands
{
    public class MoveCommand : Command
    {

        public MoveCommand()
        {
            ComSyntext = "Move";
            ComHelp = "";
        }

        public override bool TryExecute(string input)
        {
            throw new NotImplementedException();
        }
    }
}
