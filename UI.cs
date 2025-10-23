using System;
using System.Collections.Generic;
using System.Linq;

namespace ExaminationSystem
{
    public static class UI
    {
        public static void SetTitle(string title)
        {
            Console.Title = title;
        }

        public static void ClearAndDrawHeader(string title, string subtitle = "")
        {
            Console.Clear();
            DrawLine();
            WriteCentered(title, ConsoleColor.Cyan, true);
            if (!string.IsNullOrEmpty(subtitle)) WriteCentered(subtitle, ConsoleColor.DarkCyan);
            DrawLine();
            Console.WriteLine();
        }

        public static void DrawLine()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('═', Math.Min(Console.WindowWidth - 1, 120)));
            Console.ResetColor();
        }

        public static void WriteCentered(string text, ConsoleColor color = ConsoleColor.White, bool emphasize = false)
        {
            int width = Math.Min(Console.WindowWidth - 2, 120);
            string display = emphasize ? text.ToUpperInvariant() : text;
            if (display.Length >= width)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(display);
                Console.ResetColor();
                return;
            }
            int left = (width - display.Length) / 2;
            Console.ForegroundColor = color;
            Console.WriteLine(new string(' ', left) + display);
            Console.ResetColor();
        }

        public static void WriteBox(string title, IEnumerable<string> lines, ConsoleColor border = ConsoleColor.DarkMagenta)
        {
            int width = Math.Min(Console.WindowWidth - 4, 100);
            int innerWidth = Math.Max(lines.Max(l => l.Length), title.Length) + 4;
            innerWidth = Math.Min(innerWidth, width);
            string top = "╔" + new string('═', innerWidth) + "╗";
            string bot = "╚" + new string('═', innerWidth) + "╝";
            Console.ForegroundColor = border;
            Console.WriteLine(top);
            Console.Write("║");
            Console.ResetColor();
            Console.Write(new string(' ', (innerWidth - title.Length) / 2));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(title);
            Console.ResetColor();
            Console.Write(new string(' ', innerWidth - ((innerWidth - title.Length) / 2) - title.Length));
            Console.ForegroundColor = border;
            Console.WriteLine("║");
            Console.ResetColor();
            foreach (var line in lines)
            {
                Console.ForegroundColor = border;
                Console.Write("║ ");
                Console.ResetColor();
                Console.Write(line.PadRight(innerWidth - 2));
                Console.ForegroundColor = border;
                Console.WriteLine(" ║");
                Console.ResetColor();
            }
            Console.ForegroundColor = border;
            Console.WriteLine(bot);
            Console.ResetColor();
        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }

        public static void ShowWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"! {message}");
            Console.ResetColor();
        }

        public static void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✔ {message}");
            Console.ResetColor();
        }

        public static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"✖ {message}");
            Console.ResetColor();
        }
    }
}
