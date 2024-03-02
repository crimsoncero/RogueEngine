
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

            //Make a method to calculate the size of the window according to the tilemap given.
            Width = 0; 
            Height = 0;
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

            var TileRenderer = (TileConsoleRenderer)Tilemap[0, 0].Renderer;
            TileRenderer.DrawTileLeft();
            TileRenderer.DrawTileRight();

        }

        


    }


}