

class Program
{
    static void Main(string[] args)
    {
        var game = Game<ConsoleRenderer>.Create();
        game.Tilemap = new Chessboard();
        GameWindow chessWindow = new GameWindow(game.Tilemap, new Position(0, 0), false);
        game.Renderer.AddWindow(chessWindow);
        game.CommandHandler.ClearConsoleAfterInput = true;
        game.CommandHandler.AddCommand(new MoveCommand());
        game.CommandHandler.AddCommand(new SelectCommand());
        game.CommandHandler.AddCommand(new DeselectCommand());

        game.Start();

        Console.WriteLine();


    }

   

    
}

