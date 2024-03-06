//Lee


namespace RogueEngine.Renderer.Console
{
    public class GameWindow : Window
    {
        public Tilemap Tilemap { get; set; }
        public char[] RowChar { get; set; }
        public char[] ColChar { get; set; }
        public bool RenderGuidelines { get; set; }

        public GameWindow(Tilemap tilemap, IPosition topLeftAnchor,
            char[] rowChar, char[] colChar, bool renderGuidelines) : base(0, 0, topLeftAnchor)
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

            for(int i = Tilemap.Height - 1; i >= 0; i--)
            {

                // Set cursor position 
                for(int j = 0; j < Tilemap.Width; j++)
                {
                    Tile tile = Tilemap[i, j];

                    var tileRen = (TileConsoleRenderer)tile.Renderer;
                    if (tileRen != null)
                        tileRen = Settings.DefaultTileRenderer;

                    tileRen.DrawTileLeft();
                    
                    if(tile.TileObject != null)
                    {
                        TOConsoleRenderer tORen;
                        tORen = (TOConsoleRenderer)tile.TileObject.Renderer;
                        if(tORen != null)
                            tORen = Settings.DefaultTORenderer;
                    }
                }
            }
        }

        


    }


}