
using ChessDemo;
using RogueEngine;

class Program
{
    static void Main(string[] args)
    {
        var game = Game<ConsoleRenderer>.Create();
        game.Tilemap = new Chessboard();
        game.Tilemap.Init();


        Console.WriteLine();


    }

   

    
}

