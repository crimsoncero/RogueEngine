

class Program
{
    static void Main(string[] args)
    {
        var game = Game<ConsoleRenderer>.Create();
        game.Tilemap = new Chessboard();
        GameWindow chessWindow = new GameWindow(game.Tilemap, new Position(0, 0), true);

        chessWindow.RowChar = new char[] { '1', '2', '3', '4', '5', '6', '7', '8' };
        chessWindow.ColChar = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        game.Renderer.AddWindow(chessWindow);
        game.Renderer.Settings.GameTitle = "Chess - Rogue Engine Demo";
        game.CommandHandler.AddCommand(new MoveCommand());
        game.CommandHandler.AddCommand(new SelectCommand());
        game.CommandHandler.AddCommand(new DeselectCommand());
        game.CommandHandler.Settings.ColumnParse = chessWindow.ColChar;
        game.CommandHandler.Settings.RowParse = chessWindow.RowChar;


        game.EndCondition = (Tilemap t) =>
        {
            // Check if Black wins
            if ((t as Chessboard).WhiteKing.CheckIfCheckmated(t))
                return 1;

            // Check if White Wins
            if ((t as Chessboard).BlackKing.CheckIfCheckmated(t))
                return 0;
            // Tie
            return -1;
        };
        
        
        game.Start();




        Console.WriteLine();


    }



   

    
}

