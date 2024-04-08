//Lee


namespace RogueEngine.Renderer.Console
{
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
            Width = (Tilemap.Width * 3) + 2 + (RenderGuidelines ? 1 : 0);
            Height = Tilemap.Height + 2 + (RenderGuidelines ? 1 : 0);
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

            if(ColChar != null)
            {
                for (int i = 0; i < Tilemap.Height; i++)
                {
                    Position pos = new Position(TopLeftAnchor.X + 1, Tilemap.Height - i + TopLeftAnchor.Y + 1);
                    ConsoleUtil.SetCursor(pos);
                    ConsoleUtil.ChangeColor(ConsoleColor.White, ConsoleColor.Black);
                    if (i > ColChar.Length) break;
                    System.Console.Write(ColChar[i]);
                }
            }
            
            if(RowChar != null)
            {
                for (int i = 0; i < Tilemap.Width; i++)
                {
                    Position pos = new Position(TopLeftAnchor.X + 3 + (i * 3), TopLeftAnchor.Y + 1);
                    ConsoleUtil.SetCursor(pos);
                    ConsoleUtil.ChangeColor(ConsoleColor.White, ConsoleColor.Black);
                    if (i > RowChar.Length) break;
                    System.Console.Write(RowChar[i]);
                }
            }
           
        }


        private void DrawTilemap()
        {

            for(int i = 0; i < Tilemap.Height; i++)
            {
                for(int j = 0; j < Tilemap.Width; j++)
                {
                    int renX = (j * 3) + TopLeftAnchor.X + 1 + (RenderGuidelines? 1 : 0);
                    int renY = (Tilemap.Height - i) + TopLeftAnchor.Y + (RenderGuidelines ? 1 : 0);

                    DrawTile(Tilemap[j,i], new Position(renX, renY), false);

                }
            }

            if(Tilemap.SelectedTileObject != null)
            {
                TileObject tileObj = Tilemap.SelectedTileObject;
                List<Position> positions = new List<Position>();

                foreach(var path in tileObj.Movement.DerivedPaths)
                {
                    foreach(var pos in path)
                    {
                        positions.Add(pos);
                    }
                }

                foreach(var point in positions.Distinct())
                {
                    Position tilePos = point + new Position(tileObj.Position);
                    int renX = (tilePos.X * 3) + TopLeftAnchor.X + 1 + (RenderGuidelines ? 1 : 0);
                    int renY = (Tilemap.Height - tilePos.Y) + TopLeftAnchor.Y + (RenderGuidelines ? 1 : 0);
                    DrawTile(Tilemap[tilePos], new Position(renX, renY), true);
                }
            }
        }


        private void DrawTile(Tile tile, Position renderPos, bool isMove)
        {
            System.Console.CursorLeft = renderPos.X;
            System.Console.CursorTop = renderPos.Y;



            TileConsoleRenderer tileRenderer = Settings.DefaultTileRenderer;
            if (isMove)
                tileRenderer = Settings.MoveTileRenderer;
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