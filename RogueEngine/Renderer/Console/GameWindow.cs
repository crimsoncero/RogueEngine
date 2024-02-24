using RogueEngine.Position;

namespace RogueEngine.Renderer.Console
{
    public class GameWindow : Window
    {
        public int TilemapIndex { get; set; }
        public char[] RowNames { get; set; }
        public char[] ColumnNames { get; set; }
        public bool RenderGuidelines { get; set; }

        public GameWindow(int width, int height, int layerOrder, IPosition topLeftAnchor, int tilemapIndex,
            char[] rowNames, char[] columnNames, bool renderGuidelines) : base(width, height, layerOrder, topLeftAnchor)
        {
            TilemapIndex = tilemapIndex;
            RowNames = rowNames;
            ColumnNames = columnNames;
            RenderGuidelines = renderGuidelines;
        }



        public override void RenderWindow()
        {
            base.RenderWindow();
            //Draw2DArray(TileMapIndex);
        }


        private void Draw2DArray(object[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    System.Console.Write(array[i, j] + "\t");
                }
                System.Console.WriteLine();
            }
        }




    }


}