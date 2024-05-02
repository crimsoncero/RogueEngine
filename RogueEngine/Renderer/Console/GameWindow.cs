//Lee


namespace RogueEngine.Renderer.Console
{
    internal enum TileType
    {
        Normal,
        Move,
        Selected
    }


    public class GameWindow : Window
    {
        public Tilemap Tilemap { get; set; }
        public char[] RowChar { get; set; }
        public char[] ColChar { get; set; }
        public bool RenderGuidelines { get; set; }

        public GameWindow(Tilemap tilemap, IPosition topLeftAnchor, bool renderGuidelines) : base(0, 0, topLeftAnchor)
        {
            Tilemap = tilemap;
            RenderGuidelines = renderGuidelines;
            CalculateWindowSize();
        }


        private void CalculateWindowSize()
        {
            Width = (Tilemap.Width * 3) + 2 + (RenderGuidelines ? 6 : 0);
            Height = Tilemap.Height + 2 + (RenderGuidelines ? 2 : 0);
        }



        public override void RenderWindow()
        {
            base.RenderWindow();
            DrawGuidelines();
            DrawTilemap();
        }

        private void DrawGuidelines()
        {
            if (RenderGuidelines == false) return;

            if(RowChar != null)
            {

                for (int i = 0; i < Tilemap.Height; i++)
                {
                    if (i > RowChar.Length) break;
                    ConsoleUtil.ChangeColor(ConsoleColor.White, ConsoleColor.Black);
                    Position pos = new Position(TopLeftAnchor.X + 2, Tilemap.Height - i + TopLeftAnchor.Y + 1);
                    ConsoleUtil.SetCursor(pos);
                    System.Console.Write(RowChar[i]);

                    pos = new Position(TopLeftAnchor.X + 5 + Tilemap.Width*3, Tilemap.Height - i + TopLeftAnchor.Y + 1);
                    ConsoleUtil.SetCursor(pos);
                    System.Console.Write(RowChar[i]);
                }
            }
            
            if(ColChar != null)
            {
                for (int i = 0; i < Tilemap.Width; i++)
                {
                    if (i > ColChar.Length) break;
                    ConsoleUtil.ChangeColor(ConsoleColor.White, ConsoleColor.Black);
                    Position pos = new Position(TopLeftAnchor.X + 5 + (i * 3), TopLeftAnchor.Y + 1);
                    ConsoleUtil.SetCursor(pos);
                    System.Console.Write(ColChar[i]);

                    pos = new Position(TopLeftAnchor.X + 5 + (i * 3), TopLeftAnchor.Y + 2 + Tilemap.Height);
                    ConsoleUtil.SetCursor(pos);
                    System.Console.Write(ColChar[i]);
                }
            }
           
        }


        private void DrawTilemap()
        {

            for(int i = 0; i < Tilemap.Height; i++)
            {
                for(int j = 0; j < Tilemap.Width; j++)
                {
                    int renX = (j * 3) + TopLeftAnchor.X + 1 + (RenderGuidelines? 3 : 0);
                    int renY = (Tilemap.Height - i) + TopLeftAnchor.Y + (RenderGuidelines ? 1 : 0);

                    DrawTile(Tilemap[j,i], new Position(renX, renY), TileType.Normal);

                }
            }

            if (Tilemap.SelectedTileObject != null)
            {
                TileObject tileObj = Tilemap.SelectedTileObject;
                List<Position> positions = new List<Position>();

                IPosition toPos = tileObj.Position;
                int renX = (toPos.X * 3) + TopLeftAnchor.X + 1 + (RenderGuidelines ? 3 : 0);
                int renY = (Tilemap.Height - toPos.Y) + TopLeftAnchor.Y + (RenderGuidelines ? 1 : 0);
                DrawTile(Tilemap[toPos], new Position(renX, renY), TileType.Selected);


                foreach (var path in tileObj.Pathfinding.DerivedPaths)
                {
                    foreach(var pos in path)
                    {
                        positions.Add(pos);
                    }
                }

                foreach(var point in positions.Distinct())
                {
                    Position tilePos = point + new Position(tileObj.Position);
                    renX = (tilePos.X * 3) + TopLeftAnchor.X + 1 + (RenderGuidelines ? 3 : 0);
                    renY = (Tilemap.Height - tilePos.Y) + TopLeftAnchor.Y + (RenderGuidelines ? 1 : 0);
                    DrawTile(Tilemap[tilePos], new Position(renX, renY), TileType.Move);
                }
            }
        }


        private void DrawTile(Tile tile, Position renderPos, TileType tileType)
        {
            System.Console.CursorLeft = renderPos.X;
            System.Console.CursorTop = renderPos.Y;



            TileConsoleRenderer tileRenderer = Settings.DefaultTileRenderer;
            if (tileType == TileType.Move)
                tileRenderer = Settings.MoveTileRenderer;
            else if(tileType == TileType.Selected)
                tileRenderer = Settings.SelectedTileRenderer;
            else if(tile.Renderer != null)
                tileRenderer = (TileConsoleRenderer)tile.Renderer;

            TOConsoleRenderer tOConsoleRenderer = null;
            tileRenderer.DrawTileLeft();

            if(tile.IsEmpty == false )
            {
                if (tile.TileObject.Renderer != null)
                    tOConsoleRenderer = (TOConsoleRenderer)tile.TileObject.Renderer;
                else
                    tOConsoleRenderer = Settings.DefaultTORenderer;
            }
            tileRenderer.DrawTileMiddle(tOConsoleRenderer);

            tileRenderer.DrawTileRight();
            

        }

        


    }


}