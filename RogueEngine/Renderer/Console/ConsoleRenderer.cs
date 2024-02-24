
namespace RogueEngine.Renderer.Console
{
    public class ConsoleRenderer : IRenderer
    {
        private PriorityQueue<Window, int> windows;


        public ConsoleRenderer()
        {
            windows = new PriorityQueue<Window, int>();
        }

        public void AddWindow(Window window)
        {
            windows.Enqueue(window, window.LayerOrder);
        }

        public void Render()
        {
            while (windows.TryDequeue(out Window window, out int layerOrder))
            {
                System.Console.WriteLine(window);
            }
        }


    }
}

