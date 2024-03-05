using System.Text;
using Path = RogueEngine.Movements.Path;


//Game game = Game.CreateConsoleGame(); // Factory method for creating a game with specific settings: Renderer type and so on,

//// Create all the tile objects and set up their components.
//TileObject WhiteRookPrefab = new Rook();
//RookPrefab.Movement = Movement;
//RookPrefab.Renderer = new TileObjectConsoleRenderer('R', ConsoleColor.Blue, ConsoleColor.Black);


//// Create all the tiles and set up their component.
//Tile WhiteChessTilePrefab = new ChessTile();
//WhiteChessTilePrefab.Renderer = new TileConsoleRenderer('[', ']', ConsoleColor.White, ConsoleColor.Black);


//// Set up the tilemap and its settings.
//Tilemap chessBoard = new Chessboard();


//// Insert assets into the game.
//game.Assets.Tiles.Insert(WhiteRookPrefab); // Add a Tile prefab into the tiles asset list.
//game.Assets.TileObjects.Insert(WhiteChessTilePrefab); // Add a tileObject prefab into the tile object list.


//game.Tilemaps.Insert(chessBoard); // Add a tilemap to the tilemap list (you can think about it kinda like a scene in unity, but a bit different)


////// Commands set up and such


//// Renderer Set Up:


//ConsoleRenderer renderer = (ConsoleRenderer)game.Renderer; // We know it is a console renderer because that was part of the setting we set up.
//GameWindow gameWindow = new GameWindow(game.Tilemaps[0],......); // Create a game window and link the tilemap that it uses.
//LogWindow logWindow = new LogWindow(); // Set up a log window.
//renderer.Settings(); // Set up the renderer settings if we make any.





//game.Start(); // Starts the game and the show is on.


class Program
{
    static void Main(string[] args)
    {
        //Console.OutputEncoding = UTF32Encoding.Unicode;
        for(int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                ConsoleColor consoleColor;
                if (i % 2 == 0)
                    consoleColor = j % 2 == 0 ? ConsoleColor.White : ConsoleColor.DarkGray;
                else
                    consoleColor = j % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.White;

                ConsoleUtil.ChangeColor(ConsoleColor.White, consoleColor);
                Console.Write(' ');

                if(i == 0)
                {
                    ConsoleUtil.ChangeColor(ConsoleColor.Red, consoleColor);
                    switch (j)
                    {
                        case 0:
                            Console.Write('R');
                            break;
                        case 1:
                            Console.Write('N');
                            break;
                        case 2:
                            Console.Write('B');
                            break;
                        case 3:
                            Console.Write('Q');
                            break;
                        case 4:
                            Console.Write('K');
                            break;
                        case 5:
                            Console.Write('B');
                            break;
                        case 6:
                            Console.Write('N');
                            break;
                        case 7:
                            Console.Write('R');
                            break;

                    }
                }
                else if(i == 7)
                {
                    ConsoleUtil.ChangeColor(ConsoleColor.Blue, consoleColor);
                    switch (j)
                    {
                        case 0:
                            Console.Write('R');
                            break;
                        case 1:
                            Console.Write('N');
                            break;
                        case 2:
                            Console.Write('B');
                            break;
                        case 3:
                            Console.Write('K');
                            break;
                        case 4:
                            Console.Write('Q');
                            break;
                        case 5:
                            Console.Write('B');
                            break;
                        case 6:
                            Console.Write('N');
                            break;
                        case 7:
                            Console.Write('R');
                            break;

                    }
                }
                else if(i == 1 || i == 6)
                {
                    ConsoleUtil.ChangeColor(i == 1 ? ConsoleColor.Red : ConsoleColor.Blue, consoleColor);
                    Console.Write('P');
                }
                else
                    Console.Write(' ');

                Console.Write(' ');
                ConsoleUtil.ResetColor();
            }
            Console.WriteLine();
            
        }
        Console.WriteLine();
    }

    static void TestPathMakerMethods(int pathLength)
    {
        Console.WriteLine($"Testing PathMaker methods with path length = {pathLength}\n");

        // EightDirectional
        var eightDirectionalPaths = PathMaker.EightDirectional(pathLength);
        PrintPaths("EightDirectional", eightDirectionalPaths);
        
        // OrthogonalAll
        var orthogonalPaths = PathMaker.OrthogonalAll(pathLength);
        PrintPaths("OrthogonalAll", orthogonalPaths);

        // DiagonalAll
        var diagonalAllPaths = PathMaker.DiagonalAll(pathLength);
        PrintPaths("DiagonalAll", diagonalAllPaths);

        // DiagonalUp
        var diagonalUpPaths = PathMaker.DiagonalUp(pathLength);
        PrintPaths("DiagonalUp", diagonalUpPaths);

        // DiagonalDown
        var diagonalDownPaths = PathMaker.DiagonalDown(pathLength);
        PrintPaths("DiagonalDown", diagonalDownPaths);
    }

    static void PrintPaths(string methodName, ICollection<Path> paths)
    {
        Console.WriteLine($"{methodName}:");
        foreach (var path in paths)
        {
            Console.Write("[ ");
            for (int i = 0; i < path.Count; i++)
            {
                Console.Write($"({path[i].X}, {path[i].Y}) ");
            }
            Console.WriteLine("]");
        }
        Console.WriteLine();
    }
}

