
namespace RogueEngine.Commands
{
    public class MoveCommand : Command
    {

        public MoveCommand()
        {
            ComSyntext = "Move";
            ComHelp = "Move x,y: Moves to the selected location on the map.";
        }

        public override bool TryExecute(string[] input, Tilemap tilemap)
        {
            if (input.Length != 3) return false;

            int x, y;

            if (int.TryParse(input[1], out x) && int.TryParse(input[2], out y))
            {
                throw new NotImplementedException();

                return true;
            }

            return false;
        }
    }
}
