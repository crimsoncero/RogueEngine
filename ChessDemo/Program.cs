﻿using RogueEngine;
using RogueEngine.Core;
using RogueEngine.Positions;
using RogueEngine.Movements;
using RogueEngine.Util;
using RogueEngine.Renderer.Console;
using System.ComponentModel;
using ChessDemo;



Game game = Game.CreateGame(); // Factory method for creating a game with specific settings: Renderer type and so on,

// Create all the tile objects and set up their components.
TileObject WhiteRookPrefab = new Rook();
RookPrefab.AddComponent<Movement>(Movement);
RookPrefab.AddComponent<TORenderer>(TORenderer);


// Create all the tiles and set up their component.
Tile WhiteChessTilePrefab = new ChessTile();
WhiteChessTilePrefab.AddComponent<TileRenderer>(TileRenderer);


// Set up the tilemap and its settings.
Tilemap chessBoard = new Chessboard();


// Insert assets into the game.
game.Assets.Tiles.Insert(WhiteRookPrefab); // Add a Tile prefab into the tiles asset list.
game.Assets.TileObjects.Insert(WhiteChessTilePrefab); // Add a tileObject prefab into the tile object list.
game.Tilemaps.Insert(chessBoard); // Add a tilemap to the tilemap list (you can think about it kinda like a scene in unity, but a bit different)


//// Commands set up and such


// Renderer Set Up:


ConsoleRenderer renderer = (ConsoleRenderer)game.Renderer; // We know it is a console renderer because that was part of the setting we set up.
GameWindow gameWindow = new GameWindow(game.Tilemaps[0]......); // Create a game window and link the tilemap that it uses.
LogWindow logWindow = new LogWindow(); // Set up a log window.
renderer.Settings(); // Set up the renderer settings if we make any.





game.Start(); // Starts the game and the show is on.








