using System;

namespace RogueEngine.Renderer
{
    public class GameWindow : Window, IRenderer
    {
        public int TilemapIndex { get; set; }
        public char[] RowNames { get; set; }
        public char[] ColumnNames { get; set; }
        public bool RenderGuidelines { get; set; }

        public GameWindow(int width, int height, int layerOrder, IPosition topLeftAnchor, int tilemapIndex,
            char[] rowNames, char[] columnNames, bool renderGuidelines) : base(width, height, layerOrder,topLeftAnchor)
        {
            TilemapIndex = tilemapIndex;
            RowNames = rowNames;
            ColumnNames = columnNames;
            RenderGuidelines = renderGuidelines;
        }

        public void Render()
        {
            public static void Print2DArray(object[,] array)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write(array[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

    }


}