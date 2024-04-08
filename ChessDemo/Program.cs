

class Program
{
    static void Main(string[] args)
    {
        var game = Game<ConsoleRenderer>.Create();
        game.Tilemap = new Chessboard();
        GameWindow chessWindow = new GameWindow(game.Tilemap, new Position(0, 0), true);

        chessWindow.ColChar = new char[] { '1', '2', '3', '4', '5', '6', '7', '8' };
        chessWindow.RowChar = new char[] { '1', '2', '3', '4', '5', '6', '7', '8' };
        game.Renderer.AddWindow(chessWindow);
        game.CommandHandler.AddCommand(new MoveCommand());
        game.CommandHandler.AddCommand(new SelectCommand());
        game.CommandHandler.AddCommand(new DeselectCommand());

        game.Start();

        Console.WriteLine();


    }

   

    
}

