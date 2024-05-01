
namespace RogueEngine.Commands
{
    public class MoveCommand : Command
    {

        public MoveCommand()
        {
            ComSyntext = "Move";
            ComHelp = "Move x,y: Moves to the selected location on the map.";
            AdvanceTurn = true;
        }

        public override bool TryExecute(string[] input, Tilemap tilemap, int currentPlayer)
        {


            // Move can get either 2 args or 4 args (if select move)
            if (input.Length != 5 && input.Length != 3) return false;

            // If move alone, then has to have a selected tile object.
            if (input.Length == 3 && tilemap.SelectedTileObject == null) return false;

            int x, y;

            int moveXArg = 1;
            int moveYArg = 2;
            int colIndex, rowIndex;
            // Select the tileObject to move.
            if(input.Length == 5)
            {

                if (Settings.ColumnParse != null && TryParseColumn(input[1], out colIndex))
                    x = colIndex;
                else
                    return false;


                if (Settings.RowParse != null && TryParseRow(input[2], out rowIndex))
                    y = rowIndex;
                else
                    return false;

                Position position = new Position(x, y);

                if (!tilemap.IsTileObjectOwned(position, currentPlayer)) return false;
                tilemap.SelectTileObject(position);

                moveXArg = 3;
                moveYArg = 4;
            }

            if (Settings.ColumnParse != null && TryParseColumn(input[moveXArg], out colIndex))
                x = colIndex;
            else
            {
                tilemap.DeselectTileObject();
                return false;
            }


            if (Settings.RowParse != null && TryParseRow(input[moveYArg], out rowIndex))
                y = rowIndex;
            else
            {
                tilemap.DeselectTileObject();
                return false;
            }


            Position vector = new Position(x, y ) - new Position(tilemap.SelectedTileObject.Position);

            Path movePath = tilemap.SelectedTileObject.Movement.FindPathTo(vector);
            
            if (movePath == null)
            {
                tilemap.DeselectTileObject();
                return false;
            }

            tilemap.MoveTileObject(tilemap.SelectedTileObject.Position, movePath);
            return true;
        }
    }
}
