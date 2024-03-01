﻿
using System.Drawing;

namespace RogueEngine.Util
{
    public static class ConsoleUtil
    {

        public static void ChangeColor(ConsoleColor foreground, ConsoleColor background)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }

        public static void ResetColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }


    }
}
