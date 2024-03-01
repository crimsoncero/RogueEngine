


namespace RogueEngine.Renderer.Console
{
    public class LogWindow : Window
    {
        public FiniteQueue<string> Log { get; private set; }

        public LogWindow(int width, int height, int layerOrder, IPosition topLeftAnchor) : base(width, height, layerOrder, topLeftAnchor)
        {
            Log = new FiniteQueue<string>(height - 2); 
        }

        public override void RenderWindow()
        {
            base.RenderWindow();
            DrawLog();
        }

        public void InsertLogEntry(string logEntry)
        {
            // cut down logEntry to be of length "Width - 2" at max.

            Log.Enqueue(logEntry);
        }

        private void DrawLog()
        {
            //Draws the log in the window.
        }

    }
}
