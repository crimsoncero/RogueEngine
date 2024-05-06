
using RogueEngine.Positions;

namespace RogueEngine.Commands
{
    public class SelectCommand : Command
    {
        public SelectCommand()
        {
            ComSyntext = "Select";
            ComHelp = "Select x,y: Select the desired game object.";
        }

        public override bool TryExecute(string[] input, Tilemap tilemap, int currentPlayer)
        {
            if (input.Length != 3)
            {
                Settings.Console.WriteError("Invalid input count");
                return false;
            }

            int x, y;

            if (Settings.ColumnParse != null && TryParseColumn(input[1], out int colIndex))
                x = colIndex;
            else
            {
                Settings.Console.WriteError("Invalid X coordinate");
                return false;
            }


            if (Settings.RowParse != null && TryParseRow(input[2], out int rowIndex))
                y = rowIndex;
            else
            {
                Settings.Console.WriteError("Invalid Y coordinate");
                return false;
            }


            Position position = new Position(x, y);

            if (!tilemap.IsTileObjectOwned(position, currentPlayer))
            {
                Settings.Console.WriteError("Game Piece doesn't belong to player");
                return false;
            }
            tilemap.SelectTileObject(position);
            return true;

        }
    }
}

