using RogueEngine.Positions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueEngine.Renderer.Console
{
    using System;
    public enum LineWrappingType
    {
        DropLine,
        ShowEndWithDots,
        ScrollHorizontal
    }

    public class LogWindow : Window
    {
        public LineWrappingType WrappingType { get; private set; }
        public int PaddingUp { get; set; }
        private List<string> logEntries = new List<string>();

        public LogWindow(int width, int height, int layerOrder, IPosition topLeftAnchor, LineWrappingType wrappingType, int paddingUp)
            : base(width, height, layerOrder, topLeftAnchor)
        {
            WrappingType = wrappingType;
            PaddingUp = paddingUp;
        }

        public override void RenderWindow()
        {
            base.RenderWindow();
            RenderLogs();
        }

        public void AddLog(string message)
        {
            switch (WrappingType)
            {
                case LineWrappingType.DropLine:
                    logEntries.AddRange(SplitMessageDropLine(message));
                    break;
                case LineWrappingType.ShowEndWithDots:
                    logEntries.Add(CutMessageWithDots(message));
                    break;
                case LineWrappingType.ScrollHorizontal:
                    logEntries.Add(message);
                    break;
            }
        }

        private void RenderLogs()
        {
            for (int i = 0; i < Math.Min(logEntries.Count, Height - 2); i++)
            {
                Console.SetCursorPosition(TopLeftAnchor.X + 1, TopLeftAnchor.Y + 1 + i);
                Console.Write(logEntries[i].PadRight(Width - 2));
            }
        }

        private List<string> SplitMessageDropLine(string message)
        {
            List<string> lines = new List<string>();
            int start = 0;
            while (start < message.Length)
            {
                int length = Math.Min(Width - 2, message.Length - start);
                if (start + length < message.Length && message[start + length] != ' ')
                {
                    int lastSpace = message.LastIndexOf(' ', start + length, length);
                    if (lastSpace > start)
                    {
                        length = lastSpace - start;
                    }
                }
                lines.Add(message.Substring(start, length).Trim());
                start += length + 1;
            }
            return lines;
        }



        private string CutMessageWithDots(string message)
        {
            if (message.Length <= Width - 5)
            {
                return message;
            }
            return message.Substring(0, Width - 5) + "...";
        }
    }
}


































