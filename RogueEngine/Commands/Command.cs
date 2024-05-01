namespace RogueEngine.Commands
{
    public abstract class Command
    {
        /// <summary>
        /// The command keyword, not case sensitive, no spaces allowed.
        /// </summary>
        public string ComSyntext { get; init; }
        public string ComHelp { get; init; }
        public bool AdvanceTurn {  get; init; }
        internal CommandSettings Settings { get; set; }

        public abstract bool TryExecute(string[] input, Tilemap tilemap, int currentPlayer);


        protected bool TryParseRow(string input, out int rowIndex)
        {
            if (Settings.CaseSensitiveArgs)
            {
                input = input.ToUpper();
            }

            if (char.TryParse(input, out char c))
            {
                if(!Settings.CaseSensitiveArgs)
                    rowIndex = Array.FindIndex(Settings.RowParse, (d) => d == c);
                else
                    rowIndex = Array.FindIndex(Settings.RowParse, (d) => char.ToUpper(d) == c);


                if (rowIndex < 0)
                    return false;

                return true;
            }
            else
            {
                rowIndex = -1;
                return false;
            }
        }

        protected bool TryParseColumn(string input, out int colIndex)
        {
            if (!Settings.CaseSensitiveArgs)
            {
                input = input.ToUpper();
            }

            if (char.TryParse(input, out char c))
            {
                if (Settings.CaseSensitiveArgs)
                    colIndex = Array.FindIndex(Settings.ColumnParse, (d) => d == c);
                else
                    colIndex = Array.FindIndex(Settings.ColumnParse, (d) => char.ToUpper(d) == c);


                if (colIndex < 0)
                    return false;

                return true;
            }
            else
            {
                colIndex = -1;
                return false;
            }
        }
    }
}