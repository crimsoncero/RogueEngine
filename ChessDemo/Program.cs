using RogueEngine;
using RogueEngine.Position;





Position pos = new Position(2, 3);
Position pos2 = new Position(0, 4);

pos -= pos2;
Console.WriteLine(pos);