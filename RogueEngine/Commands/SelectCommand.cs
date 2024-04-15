
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

            if (Settings.ColumnParse != null && TryParseColumn(input[1], out int colIndex))
                x = colIndex;
            else
                return false;


            if(Settings.RowParse != null && TryParseRow(input[2], out int rowIndex))
                y = rowIndex;
            else
                return false;


            tilemap.SelectTileObject(new Position(x, y ));
            return true;

        }
    }
}

