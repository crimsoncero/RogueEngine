
namespace RogueEngine.Commands
{
    public class MoveCommand : Command
    {

        public MoveCommand()
        {
            ComSyntext = "Move";
            ComHelp = "Move x,y: Moves to the selected location on the map.";
        }

        public override bool TryExecute(string[] input, Game game)
        {
            throw new NotImplementedException();
        }
    }
}
