

namespace ChessDemo
{
    public class ChessSelectCom : Command
    {

        private char[] _colChar = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        private char[] _rowChar = new char[] { '1', '2', '3', '4', '5', '6', '7', '8' };

        public ChessSelectCom()
        {
            ComSyntext = "Select";
            ComHelp = "Select x,y: Select the desired game object.";
        }

        public override bool TryExecute(string[] input, Tilemap tilemap)
        {
            if (input.Length != 3) return false;

            char a, b;

            if (char.TryParse(input[1].ToUpper(), out a) && char.TryParse(input[2].ToUpper(), out b))
            {
                if (!_colChar.Contains(a) || !_rowChar.Contains(b)) return false;
                int x = Array.IndexOf(_colChar, a);
                int y = Array.IndexOf(_rowChar, b);

                tilemap.SelectTileObject(new Position(x, y));

                return true;
            }

            return false;

        }

    }
}
