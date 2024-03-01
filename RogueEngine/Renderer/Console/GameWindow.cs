using RogueEngine.Positions;

namespace RogueEngine.Renderer.Console
{
    using System;
    public class GameWindow : Window
    {
        public int TilemapIndex { get; set; }
        public char[] RowNames { get; set; }
        public char[] ColumnNames { get; set; }
        public bool RenderGuidelines { get; set; }
        private char[,] Tilemap;

        public GameWindow(int width, int height, int layerOrder, IPosition topLeftAnchor, int tilemapIndex,
            char[] rowNames, char[] columnNames, bool renderGuidelines) : base(width, height, layerOrder, topLeftAnchor)
        {
            TilemapIndex = tilemapIndex;
            RowNames = rowNames;
            ColumnNames = columnNames;
            RenderGuidelines = renderGuidelines;
        }


        public GameWindow(char[,] tilemap, int layerOrder, IPosition topLeftAnchor, int tilemapIndex,
            char[] rowNames, char[] columnNames, bool renderGuidelines) : base(tilemap.GetLength(1), tilemap.GetLength(0), layerOrder, topLeftAnchor)
        {
            Tilemap = tilemap;
            TilemapIndex = tilemapIndex;
            RowNames = rowNames;
            ColumnNames = columnNames;
            RenderGuidelines = renderGuidelines;
        }

        public void DrawTile(IPosition position, char tile)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(tile);
        }

        public void DrawObject(IPosition position, char tileObject)
        {
            DrawTile(position, tileObject);
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