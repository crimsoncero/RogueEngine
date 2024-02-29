using RogueEngine;
using RogueEngine.Positions;
using RogueEngine.Movements;
using RogueEngine.Util;

Position a = new Position(03, 2);
Position b = new Position(6, 4);

List<Position> positions = new List<Position>();
positions.Add(a);
positions.Add(b);

Path<Position> path = new Path<Position>(positions);

Console.WriteLine(path.Points.ElementAt(0));

