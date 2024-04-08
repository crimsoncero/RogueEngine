

namespace ChessDemo
{
    public class ChessMoveCom : Command
    {

        private char[] _colChar = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        private char[] _rowChar = new char[] { '1', '2', '3', '4', '5', '6', '7', '8' };

        public ChessMoveCom()
        {
            ComSyntext = "Move";
            ComHelp = "Move x,y: Moves to the selected location on the map.";
        }

        public override bool TryExecute(string[] input, Tilemap tilemap)
        {
            if (input.Length != 3) return false;
            if (tilemap.SelectedTileObject == null) return false;

            char a, b;

            if (char.TryParse(input[1].ToUpper(), out a) && char.TryParse(input[2].ToUpper(), out b))
            {
                if(!_colChar.Contains(a) || !_rowChar.Contains(b)) return false;
                int x = Array.IndexOf(_colChar, a);
                int y = Array.IndexOf(_rowChar, b);

                Position vector = new Position(x, y) - new Position(tilemap.SelectedTileObject.Position);

                Path movePath = tilemap.SelectedTileObject.Movement.FindPathTo(vector);

                if (movePath == null) return false;

                tilemap.MoveTileObject(tilemap.SelectedTileObject.Position, movePath);
                return true;
            }

            return false;
        }


    }
}
