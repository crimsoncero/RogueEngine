//Lee

namespace RogueConsoleRenderer
{
    public class LogWindow : Window
    {
        public FiniteQueue<string> Log { get; private set; }

        public LogWindow(int width, int height, IPosition topLeftAnchor) : base(width, height, topLeftAnchor)
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
            if (logEntry.Length > Width - 2)
            {
                logEntry = logEntry.Substring(0, Width - 2);
            }
            Log.Enqueue(logEntry);
        }

        private void DrawLog()
        {
            int startY = TopLeftAnchor.Y + 1;
            int startX = TopLeftAnchor.X + 1;
            foreach (string logEntry in Log)
            {
                Console.SetCursorPosition(startX, startY++);
                Console.Write(logEntry);
            }
        }

    }
}
