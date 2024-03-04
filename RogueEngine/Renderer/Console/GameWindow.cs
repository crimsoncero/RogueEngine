
namespace RogueEngine.Renderer.Console
{
    public class GameWindow : Window
    {
        public Tilemap Tilemap { get; set; }
        public char[] RowChar { get; set; }
        public char[] ColChar { get; set; }
        public bool RenderGuidelines { get; set; }

        public GameWindow(Tilemap tilemap, int layerOrder, IPosition topLeftAnchor,
            char[] rowChar, char[] colChar, bool renderGuidelines) : base(0, 0, layerOrder, topLeftAnchor)
        {
            Tilemap = tilemap;
            RowChar = rowChar;
            ColChar = colChar;
            RenderGuidelines = renderGuidelines;
            CalculateWindowSize();
        }


        private void CalculateWindowSize()
        {
            Width = Tilemap.Width * (RowChar.Length + (RenderGuidelines ? 2 : 0));
            Height = Tilemap.Height * (ColChar.Length + (RenderGuidelines ? 1 : 0));
        }



        public override void RenderWindow()
        {
            base.RenderWindow();
            //Draw2DArray(TileMapIndex);

            DrawTilemap();
        }


        private void DrawTilemap()
        {
            // This will be the complicated array;

            Tile tile = Tilemap[0, 0];
            var tileRenderer = (TileConsoleRenderer)tile.Renderer;
            tileRenderer.DrawTileLeft();
            if(tile.TileObject != null)
            {
                var tileObjectRenderer = (TileObjectConsoleRenderer)Tilemap[0, 0].TileObject.Renderer;
                tileObjectRenderer.DrawTileObject();
            }
            else
            {
                System.Console.Write(" ");
            }
            tileRenderer.DrawTileRight();

        }

        


    }


}