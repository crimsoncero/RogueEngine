
namespace RogueEngine.Commands
{
    public class SelectCommand : Command
    {
        public SelectCommand()
        {
            ComSyntext = "Select";
            ComHelp = "Select x,y: Select the desired game object.";
        }

        public override bool TryExecute(string[] input, Tilemap tilemap)
        {
            if (input.Length != 3) return false;

            int x, y;

            if (int.TryParse(input[1],out x) && int.TryParse(input[2], out y))
            {
                tilemap.SelectTileObject(new Position(x, y ));

                return true;
            }

            return false;

        }
    }
}

